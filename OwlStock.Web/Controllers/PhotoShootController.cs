using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs.PhotoShoot;
using OwlStock.Services.Facades.Interfaces;
using OwlStock.Services.Interfaces;
using System.Security.Claims;

namespace OwlStock.Web.Controllers
{
    public class PhotoShootController : Controller
    {
        private readonly IPhotoShootService _photoShootService;
        private readonly ISettlementService _settlementService;
        private readonly IPhotoshootFacade _photoshootFacade;
        
        public PhotoShootController(IPhotoShootService photoShootService, ISettlementService settlementService, IPhotoshootFacade photoshootFacade)
        {
            _photoShootService = photoShootService;
            _settlementService = settlementService;
            _photoshootFacade = photoshootFacade;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reserve()
        {
            CreateRegularPhotoShootDTO dto = new()
            {
                WorkingHoursSpan = await _photoshootFacade.GetWorkingTime(),
                Calendar = await _photoshootFacade.GetPhotoShootsCalendar(),
                ServicedRegions = (await _settlementService.GetServicedRegion()).ToList(),
            };
            
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> QuickReserve(PhotoShootType photoshootType, string firstName, string lastName, string phone)
        {
            CreateRegularPhotoShootDTO dto = new()
            {
                PhotoShootType = photoshootType,
                PersonFirstName = firstName,
                PersonLastName = lastName,
                PersonPhone = phone,
                Calendar = await _photoshootFacade.GetPhotoShootsCalendar(),
                ServicedRegions = (await _settlementService.GetServicedRegion()).ToList()
            };

            return View(nameof(Reserve), dto);
        }

        [HttpGet]
        public async Task<IActionResult> ReserveByType(PhotoShootType photoShootType)
        {
            CreateRegularPhotoShootDTO dto = new()
            {
                WorkingHoursSpan = await _photoshootFacade.GetWorkingTime(),
                PhotoShootType = photoShootType,
                Calendar = await _photoshootFacade.GetPhotoShootsCalendar(),
                ServicedRegions = (await _settlementService.GetServicedRegion()).ToList(),
            };

            return View("Reserve", dto);
        }

        [HttpGet]
        public IActionResult ReserveSmallProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(CreateRegularPhotoShootDTO dto)
        {
            //When photoshoot's place is decided by the studio or a popular place is selected
            //UserPlace (the name of the place that is created by the user) is no longer required
            //and remove the Id of the select place from the ModelState since
            //no place was selected
            if (dto.IsDecidedByUs)
            {
                ModelState.Remove("UserPlace");
                ModelState.Remove("PlaceId");
            }

            //if there is a custom place created remove the PlaceId (the Id of a popular place)
            else if(!dto.UserPlace.IsNullOrEmpty())
            {
                ModelState.Remove("PlaceId");
            }

            //else a popular place must have been selected, so remove the UserPlace (the custom place)
            else
            {
                ModelState.Remove("UserPlace");
            }

            //return error if ModelState is invalid
            //There is a solid validation in the front end, so
            //invalid model state  should not be possible
            if (!ModelState.IsValid)
            {
                return View("Error", "Съжаляваме, нещо се обърка повреме на резервирането...");
                
            }

            //Photoshoot description is required when photshoot type is Other
            if(dto.PhotoShootType == PhotoShootType.Other && dto.PhotoShootTypeDescription.IsNullOrEmpty())
            {
                ModelState.AddModelError(string.Empty, "Описането на фотосесията е задължително");

                dto.Calendar = await _photoshootFacade.GetPhotoShootsCalendar();
                return View(dto);
            }

            dto.IdentityUserId = GetUserId();

            bool isSuccessfull = await _photoshootFacade.ReservePhotoshoot(dto);

            if (!isSuccessfull)
            {
                return View("Error", "Съжаляваме, нещо се обърка повреме на резервирането...");
            }
            
            return RedirectToAction(nameof(SuccessfulReservation));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReserveSmallProduct(CreateSmallProductPhotoshootDTO dto)
        {
            //return error if ModelState is invalid
            //There is a solid validation in the front end, so
            //invalid model state  should not be possible
            if (!ModelState.IsValid)
            {
                return View("Error", "Съжаляваме, нещо се обърка повреме на резервирането...");

            }

            dto.IdentityUserId = GetUserId();

            bool isSuccessful = await _photoshootFacade.ReserveSmallProductPhotoshoot(dto);

            if (isSuccessful)
            {
                return RedirectToAction(nameof(SuccessfulReservation));
            }

            return View("Error", "Съжаляваме, нещо се обърка по време на резервирането...");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyPhotoShoots()
        {
            return View(await _photoShootService.MyPhotoShoots(GetUserId()));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PhotoShootById(Guid id)
        {
            PhotoShootByIdDTO? dto = await _photoShootService.PhotoShootById(id, GetUserId());
            
            if (dto.Id == Guid.Empty)
            {
                return View("Error", "Не намерихме фотосесията, която търсите");
            }

            return View(dto);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        [HttpGet]
        public IActionResult SuccessfulReservation()
        {
            return View("_SucessfulReservation");
        }
    }
}
