using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdministrationService> _logger;
        
        public AdministrationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AdministrationService> logger)
        {
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
        public async Task<string> CreateUser(IdentityUser user)
        {
            if(user == null)
            {
                _logger.LogInformation("{user} is null in {Method}, {Class}, {DateTime}", nameof(user), nameof(CreateUser), nameof(AdministrationService), DateTime.Now);
                return string.Empty;
            }
            if (user.Email.IsNullOrEmpty())
            {
                _logger.LogInformation("{email)} is null or empty in {Method}, {Class}, {DateTime}", nameof(user.Email), nameof(CreateUser), nameof(AdministrationService), DateTime.Now);
                return string.Empty;
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
                        return password;
                    }
                }

                return string.Empty;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return string.Empty;
            }
        }

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
