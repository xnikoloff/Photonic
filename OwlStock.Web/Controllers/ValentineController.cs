using Microsoft.AspNetCore.Mvc;

namespace OwlStock.Web.Controllers
{
    public class ValentineController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Request()
        {
            return View();
        }
    }
}
