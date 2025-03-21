using Microsoft.AspNetCore.Identity;

namespace OwlStock.Services.Interfaces
{
    public interface IAdministrationService
    {
        Task<string> CreateUser(IdentityUser user);
    }
}
