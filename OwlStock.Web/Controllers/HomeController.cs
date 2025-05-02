using Microsoft.AspNetCore.Mvc;
using OwlStock.Services.DTOs.HomePage;
using OwlStock.Services.Facades.Interfaces;

namespace OwlStock.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeFacade _homeFacade;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public HomeController(IHomeFacade homeFacade, IWebHostEnvironment webHostEnvironment)
        {
            _homeFacade = homeFacade;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            HomePageDTO homePageDTO = await _homeFacade.GetHomeData();
            string? photo = homePageDTO?.Photo;
            string photoPath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "resources", photo ?? "");
            string photoPathSlashes = photoPath.Replace("/", "\\");

            if(System.IO.File.Exists(photoPathSlashes))
            {
                ViewBag.HomePhoto = photo;
            }
            
            return View(homePageDTO);
        }
    }
}
