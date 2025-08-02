using Microsoft.AspNetCore.Identity;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs.Identity;

namespace OwlStock.Services.Interfaces
{
    public interface IAdministrationService
    {
        Task<CreateIdentityUserDTO> CreateUser(IdentityUser user);
        Task<string> GetUserEmailByIdAsync(string userId);
        Task<IdentityUser?> GetUserByEmailAsync(string email);
        Task<IEnumerable<WorkingTime>> GetWorkingTime();
        Task<WorkingTime> GetWorkingTimeByType(WorkingTimeType workingTimeType);
        Task<bool> SetWorkingTime(WorkingTime workingTime);
    }
}
