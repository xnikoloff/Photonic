using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.GiftCard;
using OwlStock.Services.Interfaces;
using SixLabors.ImageSharp.PixelFormats;
using System.Security.Claims;

namespace OwlStock.Web.Controllers
{
    [Route("podarachni-vaucheri")]
    public class GiftCardController : Controller
    {
        private readonly IGiftCardService _giftCardService;
        private readonly IPdfService _pdfService;

        public GiftCardController(IGiftCardService giftCardService, IPdfService pdfService)
        {
            _giftCardService = giftCardService;
            _pdfService = pdfService;
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

            return View(giftCard);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(GiftCard giftCard)
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
