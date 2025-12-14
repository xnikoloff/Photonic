using Microsoft.AspNetCore.Mvc;

namespace OwlStock.Web.Controllers
{
    public class StaticContentController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StaticContentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Services()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Pricing()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FAQ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TermsAndConditions()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Wedding()
        {
            return View("PhotoshootTypes/Wedding");
        }

        [HttpGet]
        public IActionResult Prom()
        {
            return View("PhotoshootTypes/Prom");
        }

        [HttpGet]
        public IActionResult Baptism()
        {
            return View("PhotoshootTypes/Baptism");
        }

        [HttpGet]
        public IActionResult Product()
        {
            return View("PhotoshootTypes/Product");
        }

        [HttpGet]
        public IActionResult Family()
        {
            return View("PhotoshootTypes/Family");
        }

        [HttpGet]
        public IActionResult Event()
        {
            return View("PhotoshootTypes/Event");
        }

        [HttpGet]
        public IActionResult Portrait()
        {
            return View("PhotoshootTypes/Portrait");
        }

        [HttpGet]
        public IActionResult BusinessPortrait()
        {
            return View("PhotoshootTypes/BusinessPortrait");
        }

        [HttpGet]
        public IActionResult Automobile()
        {
            return View("PhotoshootTypes/Automobile");
        }

        [HttpGet]
        public IActionResult SecretPhotoshoot()
        {
            return View("PhotoshootTypes/SecretPhotoshoot");
        }

        [HttpGet]
        public ContentResult Sitemap()
        {
            string sitemapPath = Path.Combine(_webHostEnvironment.WebRootPath, "sitemap.xml");

            if (!System.IO.File.Exists(sitemapPath))
            {
                return new ContentResult
                {
                    Content = "",
                    ContentType = "application/xml",
                    StatusCode = 404
                };
            }

            string sitemap = System.IO.File.ReadAllText(sitemapPath);

            return new ContentResult
            {
                Content = sitemap,
                ContentType = "application/xml",
                StatusCode = 200
            };
        }
    }
}
