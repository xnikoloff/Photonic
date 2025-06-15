using Microsoft.AspNetCore.Mvc;

namespace OwlStock.Web.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Error(string message)
        {
            return View(message);
        }
    }
}
