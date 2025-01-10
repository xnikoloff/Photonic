using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.HomePage;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDynamicContentService _dynamicContentService;
        private readonly IHomeService _homeService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public HomeController(IDynamicContentService dynamicContentServic, IHomeService homeService,
            IWebHostEnvironment webHostEnvironment)
        {
            _dynamicContentService = dynamicContentServic;
            _homeService = homeService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            HomePageDTO homePageDTO = await _homeService.GetHomeData();
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
