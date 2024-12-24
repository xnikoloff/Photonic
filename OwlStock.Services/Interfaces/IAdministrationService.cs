using Microsoft.AspNetCore.Identity;

namespace OwlStock.Services.Interfaces
{
    public interface IAdministrationService
    {
        string GeneratePassword();
        Task<string> CreateUserFromGuest(IdentityUser user);
    }
}
