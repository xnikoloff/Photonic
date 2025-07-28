using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;
using OwlStock.Services.DTOs.Identity;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly OwlStockDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdministrationService> _logger;
        
        public AdministrationService(OwlStockDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AdministrationService> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        /// Creates IdentityUser
        /// </summary>
        /// <param name="user">IdentityUser</param>
        /// <returns>Password of the created user as string if creation was successful, else return empty string </returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CreateIdentityUserDTO> CreateUser(IdentityUser user)
        {
            if(user == null)
            {
                _logger.LogError("{user} is null in {Method}, {Class}, {DateTime}", nameof(user), nameof(CreateUser), nameof(AdministrationService), DateTime.Now);
                return new()
                {
                    IdentityUserId = string.Empty,
                    Password = string.Empty
                };
            }
            if (user.Email.IsNullOrEmpty())
            {
                _logger.LogError("{email)} is null or empty in {Method}, {Class}, {DateTime}", nameof(user.Email), nameof(CreateUser), nameof(AdministrationService), DateTime.Now);
                return new()
                {
                    IdentityUserId = string.Empty,
                    Password = string.Empty
                };
            }

            try
            {
                user.EmailConfirmed = true;
                string password = GeneratePassword();
                IdentityResult result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    IdentityResult resultRole = await _userManager.AddToRoleAsync(user, "User");

                    if (resultRole.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return new()
                        {
                            IdentityUserId = user.Id,
                            Password = password
                        };
                    }
                }

                return new()
                {
                    IdentityUserId = string.Empty,
                    Password = string.Empty
                };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new()
                {
                    IdentityUserId = string.Empty,
                    Password = string.Empty
                };
            }
        }

        /// <summary>
        /// Gets user email by the provided user id
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>Email of the user as string</returns>
        public async Task<string> GetUserEmailByIdAsync(string userId)
        {
            if (userId.IsNullOrEmpty())
            {
                return string.Empty;
            }

            try
            {
                string? email = await _userManager.GetEmailAsync(new IdentityUser() { Id = userId });

                if (email == null)
                {
                    return string.Empty;
                }

                return email;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets user by the provided email
        /// </summary>
        /// <param name="userId">Email of the user</param>
        /// <returns>An IdentityUser object</returns>
        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            if (email.IsNullOrEmpty())
            {
                return new();
            }

            try
            {
                IdentityUser? user = await _userManager.FindByEmailAsync(email);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        /// <summary>
        /// Sets the working time for the calendar
        /// </summary>
        /// <param name="start">Starting hour for the timeslots</param>
        /// <param name="end">End hour for the timeslots</param>
        /// <returns>True if successful, false if failed</returns>
        public async Task<bool> SetWorkingTime(WorkingTime workingTime)
        {
            if (_context.WorkingTime is null)
            {
                _logger.LogError("{context} is null in {Method}, {Class}, {DateTime}", nameof(_context.WorkingTime), nameof(SetWorkingTime), nameof(AdministrationService), DateTime.Now);
                return false;
            }

            try
            {
                WorkingTime? existingWorkingTime = await _context.WorkingTime.FirstOrDefaultAsync();

                if (existingWorkingTime == null)
                {
                    await _context.WorkingTime.AddAsync(workingTime);
                }

                else
                {
                    existingWorkingTime!.Start = workingTime.Start;
                    existingWorkingTime!.End = workingTime.End;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }

        /// <summary>
        /// Generates password for user with
        /// uppercase, lowercase, number and special char
        /// </summary>
        /// <returns>The generated password as string</returns>
        private string GeneratePassword()
        {
            string password = "";
            
            string[] charGroups =
            {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",   // Uppercase
                "abcdefghijklmnopqrstuvwxyz",   // Lowercase
                "0123456789",                   // Digits
                "!#$"        // Non-alphanumeric
            };

            Random random = new();

            try
            {
                for (int i = 0; i < 3; i++)
                {

                    string uppercase = charGroups[0][random.Next(charGroups[0].Length)].ToString();
                    string lowerrcase = charGroups[1][random.Next(charGroups[1].Length)].ToString();
                    string digit = charGroups[2][random.Next(charGroups[2].Length)].ToString();
                    string special = charGroups[3][random.Next(charGroups[3].Length)].ToString();

                    password += uppercase + lowerrcase + digit + special;
                }

                return password;
            }

            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred at {Time}", DateTime.UtcNow);
                return string.Empty;
            }

            
        }
    }
}
