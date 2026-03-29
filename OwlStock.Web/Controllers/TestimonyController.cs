using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.Testimonies;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Controllers
{
    [Route("otzivi")]
    public class TestimonyController : Controller
    {
        private readonly ITestimonyService _testimonyService;

        public TestimonyController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }

        [HttpGet("")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTestimonyDTO dto)
        {
            if (dto.ReCaptchaToken.IsNullOrEmpty())
            {
                ModelState.AddModelError(string.Empty, $"Липсва проверка за робот");
                return View(dto);
            }

            if (!ModelState.IsValid) 
            {
                return View(dto);
            }

            await _testimonyService.Create(dto.Testimony ?? new Testimony());
            return RedirectToAction(nameof(SuccessfulTestimony));
        }

        [HttpGet("blagodarim-za-otziva")]
        public IActionResult SuccessfulTestimony()
        {
            return View("_SuccessfulTestimony");
        }
    }
}
