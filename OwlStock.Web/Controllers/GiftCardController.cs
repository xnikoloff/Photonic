using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs;
using OwlStock.Services.Interfaces;
using SixLabors.ImageSharp.PixelFormats;

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

        [HttpGet("nov-vaucher")]
        public IActionResult Template()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("porachka")]
        public async Task<IActionResult> Order(CreateGiftCardDTO dto)
        {
            GiftCard giftCard = await _giftCardService.Create(dto.GiftCard ?? new());
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
    }
}
