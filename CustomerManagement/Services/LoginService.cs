using CustomerManagement.Data;
using CustomerManagement.DTO.Account;
using CustomerManagement.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerManagement.Services
{
    public class LoginService : ILogin
    {
        private readonly ApplicationDbContext db;
        private readonly IConfiguration config;

        public LoginService(ApplicationDbContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public async Task<string?> LoginAsync(UserData data)
        {

            var user = db.Users.FirstOrDefault(u => u.Username == data.UserName);


            if (user == null || user.Password != data.Password)
                return null;


            data.UserId = user.UserId;
            data.UserName = user.Username;
            data.Role = user.Role;
            data.Password = null;


            return GenerateJwtToken(data);
        }

        public string GenerateJwtToken(UserData user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role ?? "User"),
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
