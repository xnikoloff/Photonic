using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure.Common.EmailTemplates.Inquiry;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Controllers
{
    public class InquiryController : Controller
    {
        private readonly IEmailService _emailService;

        public InquiryController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult SuccessfulInquiry()
        {
            return View("_SuccessfulInquiry");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendInquiry(SendInquiryEmailTemplateDTO dto)
        {
            if (dto.Name.IsNullOrEmpty() || dto.From.IsNullOrEmpty() || dto.Topic.IsNullOrEmpty() || dto.Content.IsNullOrEmpty())
            {
                //remove validation from the parrent class of the DTO
                ModelState.Remove("From");

                ModelState.AddModelError("", "Попълнете всички полета");
                return View("../StaticContent/Contacts", dto);
            }

            dto.EmailTemplate = EmailTemplate.SendInquiry;
            bool result = await _emailService.Send(dto);

            if(!result)
            {
                return View("Error", "Получи се грешка при изпращането на запитването Ви. Моля опитайте отново.");
            }

            return RedirectToAction(nameof(SuccessfulInquiry));
        }
    }
}
