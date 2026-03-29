using Microsoft.AspNetCore.Mvc;

namespace OwlStock.Web.Controllers
{
    [Route("usulugi")]
    public class ServicesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServicesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        
        [HttpGet("svatbena-fotografiya")]
        public IActionResult Wedding()
        {
            return View();
        }
        
        [HttpGet("fotosesiya-abiturienti")]
        public IActionResult Prom()
        {
            return View();
        }

        [HttpGet("sveto-krashtene")]
        public IActionResult Baptism()
        {
            return View();
        }

        [HttpGet("individualni-semeyni-fotosesii")]
        public IActionResult Individual()
        {
            return View();
        }

        [HttpGet("biznes-fotografiya")]
        public IActionResult Business()
        {
            return View();
        }

        [HttpGet("avtomobilna-fotografiya")]
        public IActionResult Automotive()
        {
            return View();
        }

        [HttpGet("tayna-fotosesiya")]
        public IActionResult SecretPhotoshoot()
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
