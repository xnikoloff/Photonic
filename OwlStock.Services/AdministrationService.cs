using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class AdministrationService : IAdministrationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public AdministrationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateUserFromGuest(IdentityUser user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (user.Email.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(user.Email));
            }

            string password = GeneratePassword();
            IdentityResult result = await _userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return password;
            }

            return string.Empty;
        }

        public string GeneratePassword()
        {
            string password = "";
            
            string[] charGroups =
            {
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",   // Uppercase
                "abcdefghijklmnopqrstuvwxyz",   // Lowercase
                "0123456789",                   // Digits
                "!@#$"        // Non-alphanumeric
            };

            Random random = new();

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
    }
}
