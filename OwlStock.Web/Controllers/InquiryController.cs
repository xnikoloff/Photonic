using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> SendInquiry(SendInquiryEmailTemplateDTO dto)
        {
            dto.EmailTemplate = EmailTemplate.SendInquiry;
            await _emailService.Send(dto);
            return RedirectToAction(nameof(SuccessfulInquiry));
        }
    }
}
