using Microsoft.AspNetCore.Identity;
using OwlStock.Services.DTOs.Identity;

namespace OwlStock.Services.Interfaces
{
    public interface IAdministrationService
    {
        Task<CreateIdentityUserDTO> CreateUser(IdentityUser user);
        Task<string> GetUserEmailByIdAsync(string userId);
        Task<IdentityUser?> GetUserByEmailAsync(string email);
    }
}
