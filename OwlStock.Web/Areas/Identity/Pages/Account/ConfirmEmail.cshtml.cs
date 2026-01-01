// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure.Common.EmailTemplates.Account;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Areas.Identity.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailService _emailSender;

        public ConfirmEmailModel(UserManager<IdentityUser> userManager, IEmailService emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        /// 

        //custom property to show if a confirmation was successful
        public bool IsSuccessful { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId, string encodedToken, string email)
        {
            if (userId == null || encodedToken == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            encodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(encodedToken));
            var result = await _userManager.ConfirmEmailAsync(user, encodedToken);

            if (result.Succeeded)
            {
                StatusMessage =  "Профилът Ви е потвърден";
                IsSuccessful = true;

                await _emailSender.Send(new CreateAccountEmailTemplateDTO()
                {
                    Recipient = email,
                    Topic = "Успешна регистрация във Photonic",
                    EmailTemplate = EmailTemplate.CreateConfirmedAccount,
                });
            }

            else
            {
                StatusMessage = "Получи се грешка при потвърждението на профилът Ви";
                IsSuccessful = false;
            }

            
            return Page();
        }
    }
}
