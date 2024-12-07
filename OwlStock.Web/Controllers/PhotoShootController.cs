using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs.PhotoShoot;
using OwlStock.Services.Interfaces;
using System.Security.Claims;

namespace OwlStock.Web.Controllers
{
    [Authorize]
    public class PhotoShootController : Controller
    {
        private readonly IPhotoShootService _photoShootService;
        private readonly ISettlementService _settlementService;
        private readonly IPlaceService _placeService;
        
        public PhotoShootController(IPhotoShootService photoShootService, ISettlementService settlementService, IPlaceService placeService)
        {
            _photoShootService = photoShootService;
            _settlementService = settlementService;
            _placeService = placeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Reserve()
        {
            CreatePhotoShootDTO dto = new()
            {
                Calendar = await _photoShootService.GetPhotoShootsCalendar(),
                ServicedRegions = (await _settlementService.GetServicedRegion()).ToList(),
            };
            
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> QuickReserve(PhotoShootType photoshootType, string firstName, string lastName, string phone)
        {
            CreatePhotoShootDTO dto = new()
            {
                PhotoShootType = photoshootType,
                PersonFirstName = firstName,
                PersonLastName = lastName,
                PersonPhone = phone,
                Calendar = await _photoShootService.GetPhotoShootsCalendar(),
                ServicedRegions = (await _settlementService.GetServicedRegion()).ToList()
            };

            return View(nameof(Reserve), dto);
        }

        [HttpGet]
        public async Task<IActionResult> ReserveByType(PhotoShootType photoShootType)
        {
            CreatePhotoShootDTO dto = new()
            {
                PhotoShootType = photoShootType,
                Calendar = await _photoShootService.GetPhotoShootsCalendar(),
                ServicedRegions = (await _settlementService.GetServicedRegion()).ToList(),
            };

            return View(nameof(Reserve), dto);
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(CreatePhotoShootDTO dto)
        {
            //When photoshoot's place is decided by the studio or a popular place is selected
            //UserPlace (the name of the place that is created by the user) is no longer required
            if (dto.IsDecidedByUs || dto.IsPlaceSelected)
            {
                ModelState.Remove("UserPlace");
            }

            //return to the view if the ModelState is not vaild
            if (!ModelState.IsValid)
            {
                dto.Calendar = await _photoShootService.GetPhotoShootsCalendar();
                dto.ServicedRegions = (await _settlementService.GetServicedRegion()).ToList();
                return View(dto);
            }

            //Photoshoot description is required when photshoot type is Other
            if(dto.PhotoShootType == PhotoShootType.Other && dto.PhotoShootTypeDescription.IsNullOrEmpty())
            {
                ModelState.AddModelError(string.Empty, "Описането на фотосесията е задължително");

                dto.Calendar = await _photoShootService.GetPhotoShootsCalendar();
                return View(dto);
            }

            //get user id and email
            dto.IdentityUserId = GetUserId();
            dto.PersonEmail = User.FindFirstValue(ClaimTypes.Email);

            //Create new place if UserPlace is not null
            if (!string.IsNullOrEmpty(dto.UserPlace))
            {
                Place? place = await _placeService.Create(new()
                {
                    CityId = Convert.ToInt32(dto.SelectedSettlementId),
                    IsPopular = false,
                    Name = dto.UserPlace,
                    GoogleMapsURL = dto.GoogleMapsLink,

                });

                //Return error if place was not created
                if (place == null)
                {
                    return View("Error", "Нещо се обърка повреме на резервирането...");
                }
                
                //Set the newly created place id
                dto.PlaceId = place.Id;
            }
           
            //If reached that line, everything is OK,
            //create the photoshoot
            await _photoShootService.Add(dto);
            return View("_SucessfulReservation");
        }

        [HttpGet]
        public async Task<IActionResult> MyPhotoShoots()
        {
            List<MyPhotoShootsDTO> myPhotoShoots = await _photoShootService.MyPhotoShoots(GetUserId());
            return View(myPhotoShoots);
        }

        [HttpGet]
        public async Task<IActionResult> PhotoShootById(Guid id)
        {
            PhotoShootByIdDTO? dto = await _photoShootService.PhotoShootById(id, GetUserId());
            
            if (dto == null)
            {
                return View("Error", "Несъществуваща фотосесия");
            }
            return View(dto);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                throw new NullReferenceException("User not logged in");
        }
    }
}
