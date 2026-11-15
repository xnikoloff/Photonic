using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure.Common.EmailTemplates.GiftCard;
using OwlStock.Services.DTOs.GiftCard;
using OwlStock.Services.Interfaces;
using System.Security.Claims;

namespace OwlStock.Web.Controllers
{
    [Route("podarachni-vaucheri")]
    public class GiftCardController : Controller
    {
        private readonly IGiftCardService _giftCardService;
        private readonly IPdfService _pdfService;
        private readonly IEmailService _emailService;

        public GiftCardController(IGiftCardService giftCardService, IPdfService pdfService, IEmailService emailService)
        {
            _giftCardService = giftCardService;
            _pdfService = pdfService;
            _emailService = emailService;
        }

        [HttpGet("vaucher")]
        public async Task<IActionResult> GiftCardById(Guid id)
        {
            return View(await _giftCardService.GetById(id));
        }

        [HttpGet("moite-vaucheri")]
        public async Task<IActionResult> MyGiftCards()
        {
            return View(await _giftCardService.GiftCardsByUser(GetUserId()));
        }

        [Authorize]
        [HttpGet("nov-vaucher")]
        public IActionResult Template()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("porachka")]
        public async Task<IActionResult> Order(CreateGiftCardDTO dto)
        {
            dto.IdentityUserId = GetUserId();
            GiftCard giftCard = await _giftCardService.Create(dto ?? new());

            if(giftCard.Id == Guid.Empty)
            {
                return View("Error", "Възникна грешка при създаването на Вашия ваучер. Моля опитайте по-късно.");
            }

            //send email
            GiftCardEmailTemplateDTO emailDto = new()
            {
                Id = giftCard.Id,
                Topic = "Нов подаръчен ваучер",
                Price = giftCard.Price.ToString(),
                PhotoShootType = giftCard.PhotoShootType,
                EmailTemplate = EmailTemplate.CreateGiftCard,
                GiftCardNumber = giftCard.GiftCardNumber,
                Recipient = User?.Identity?.Name,
            };

            bool isPhotoshootEmailSent = await _emailService.Send(emailDto);

            if (!isPhotoshootEmailSent)
            {
                return View("Error", "Неуспешно създаване на ваучер");
            }

            return View(giftCard);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Create(GiftCard giftCard)
        {
            string html = _giftCardService.GetHtmlTemplate(giftCard);
            byte[]? pdf = _pdfService.GeneratePdfFromHtml(html);

            if (pdf != null)
            {
                return File(pdf, "application/pdf", "ваучер.pdf");
            }

            else
            {
                return View("Error", "Неуспешно създаване на ваучер");
            }
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}
