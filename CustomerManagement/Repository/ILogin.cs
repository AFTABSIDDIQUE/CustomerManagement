using CustomerManagement.DTO.Account;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Repository
{
    public interface ILogin
    {
        Task<string ?> LoginAsync(UserData data);
        string GenerateJwtToken(UserData user);
    }
}
