using Microsoft.AspNetCore.Identity;

namespace OwlStock.Services.Interfaces
{
    public interface IAdministrationService
    {
        string GeneratePassword();
        Task<bool> CreateUserFromGuest(IdentityUser user);
    }
}
