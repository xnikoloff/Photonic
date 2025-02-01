using Microsoft.AspNetCore.Mvc;
using OwlStock.Services.Interfaces;

namespace OwlStock.Web.Components
{
    public class AnnouncementViewComponent : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementViewComponent(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
         public async Task<IViewComponentResult> InvokeAsync()
        {
            var s = await _announcementService.GetActive();
            return View(s);
        }
    }
}
