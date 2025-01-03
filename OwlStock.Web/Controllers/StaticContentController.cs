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
