using Microsoft.AspNetCore.Mvc;
using OwlStock.Services.DTOs.PhotoShoot;

namespace OwlStock.Web.Components
{
    public class QuickBookingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new CreateRegularPhotoShootDTO());
        }
    }
}
