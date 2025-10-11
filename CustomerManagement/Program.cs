using CustomerManagement.Data;
using CustomerManagement.Repository;
using CustomerManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add DbContext into the project
builder.Services.AddDbContext<ApplicationDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));

//Add AutoMapper in the project for mapping datas
builder.Services.AddAutoMapper(typeof(Program));

//Adding DI 
builder.Services.AddScoped<ICustomer,CustomerService>();
builder.Services.AddScoped<IServices, ServiceService>();
builder.Services.AddScoped<ICustomerHandler, CustomerHandlerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
