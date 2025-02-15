// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure.Common.EmailTemplates.Account;
using OwlStock.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OwlStock.Web.Areas.Identity.Pages.Account
{
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        private readonly IEmailService _emailService;

        public ForgotPasswordConfirmation(UserManager<IdentityUser> userManager, IEmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Email { get; set; }
            public string CallbackUrl { get; set; }
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public void OnGet(string email, string callbackUrl) 
        {
            Input = new()
            {
                Email = email,
                CallbackUrl = callbackUrl
            };
        }

        public async Task<IActionResult> OnPostResendEmail()
        {
             await _emailService.Send(new ResetPasswordEmailTemplateDTO()
            {
                From = "hristiyan.at.nikoloff@gmail.com",
                Recipient = Input.Email ?? "",
                Topic = "Забравена парола",
                EmailTemplate = EmailTemplate.ResetPassword,
                CallBackURL = Input.CallbackUrl ?? "",
            });

            return Page();
        }
    }
}
