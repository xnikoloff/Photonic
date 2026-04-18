using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Controllers
{
    [Route("podarachni-vaucheri")]
    public class GiftCardController : Controller
    {
        private readonly IGiftCardService _giftCardService;

        public GiftCardController(IGiftCardService giftCardService)
        {
            _giftCardService = giftCardService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("nov-vaucher")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("nov-vaucher")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiftCard giftCard)
        {
            bool result = await _giftCardService.Create(giftCard);

            if (result)
            {
                return View();
            }

            else
            {
                return View("Error", "Неуспешно създаване на ваучер");
            }
        }
    }
}
