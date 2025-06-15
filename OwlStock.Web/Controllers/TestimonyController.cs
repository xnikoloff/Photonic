using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Controllers
{
    public class TestimonyController : Controller
    {
        private readonly ITestimonyService _testimonyService;

        public TestimonyController(ITestimonyService testimonyService)
        {
            _testimonyService = testimonyService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Testimony testimony)
        {
            if (!ModelState.IsValid) 
            {
                return View(testimony);
            }

            await _testimonyService.Create(testimony);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
