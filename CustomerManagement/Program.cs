using CustomerManagement.Data;
using CustomerManagement.Repository;
using CustomerManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------------------------
// Add services to the container
// -----------------------------------------------------------------------------
builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// -----------------------------------------------------------------------------
//  Database Context
// -----------------------------------------------------------------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));

// -----------------------------------------------------------------------------
//  AutoMapper
// -----------------------------------------------------------------------------
builder.Services.AddAutoMapper(typeof(Program));

// -----------------------------------------------------------------------------
//  Dependency Injection (Repositories / Services)
// -----------------------------------------------------------------------------
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<IServices, ServiceService>();
builder.Services.AddScoped<ICustomerHandler, CustomerHandlerService>();
builder.Services.AddScoped<IDashboard, DashboardService>();
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IStock, StockServices>();

// -----------------------------------------------------------------------------
//  Session Configuration
// -----------------------------------------------------------------------------
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// -----------------------------------------------------------------------------
//  JWT Authentication Setup
// -----------------------------------------------------------------------------
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// -----------------------------------------------------------------------------
var app = builder.Build();

// -----------------------------------------------------------------------------
//  Configure the HTTP request pipeline
// -----------------------------------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// -----------------------------------------------------------------------------
//  Enable Session (must be before authentication)
// -----------------------------------------------------------------------------
app.UseSession();

//  Middleware: Add JWT token from session into request headers automatically
app.Use(async (context, next) =>
{
    var token = context.Session.GetString("JWTToken");

    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }

    await next();
});

//  Middleware: Redirect unauthorized (401) users to login page
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 401)
    {
        context.HttpContext.Response.Redirect("/Account/Index");
    }
});

// -----------------------------------------------------------------------------
//  Enable Authentication and Authorization
// -----------------------------------------------------------------------------
app.UseAuthentication();
app.UseAuthorization();

// -----------------------------------------------------------------------------
// Default Route
// -----------------------------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

// -----------------------------------------------------------------------------
app.Run();
