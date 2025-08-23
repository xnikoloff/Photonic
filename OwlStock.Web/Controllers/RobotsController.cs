using Microsoft.AspNetCore.Mvc;

namespace OwlStock.Web.Controllers
{
    [Route("robots.txt")]
    public class RobotsController : Controller
    {
        [HttpGet]
        public IActionResult Robots()
        {
            var host = HttpContext.Request.Host.Host;

            if (host.Contains("test", StringComparison.OrdinalIgnoreCase) ||
                host.Contains("studio", StringComparison.OrdinalIgnoreCase))
            {
                return Content("User-agent: *\nDisallow: /", "text/plain");
            }

            return Content("User-agent: *\nAllow: /", "text/plain");
        }
    }
}
