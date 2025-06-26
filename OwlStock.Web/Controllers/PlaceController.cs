using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs;
using OwlStock.Services.DTOs.Place;
using OwlStock.Services.Interfaces;
using OwlStock.Web.DTOs.PlaceDTOs;
using System.Security.Claims;

namespace OwlStock.Web.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceService _placeService;
        private readonly ISettlementService _settlementService;
        private readonly IFileService _fileService;
        private readonly IPhotoService _photoService;
        private readonly IPhotoResizer _photoResizer;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PlaceController(IPlaceService placeService, ISettlementService settlementService,
            IFileService fileService, IPhotoService photoService, IPhotoResizer photoResizer, 
            IWebHostEnvironment webHostEnvironment
            ) 
        {
            _placeService = placeService;
            _settlementService = settlementService;
            _fileService = fileService;
            _photoService = photoService;
            _photoResizer = photoResizer;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await _placeService.All());
        }

        [HttpGet]
        public async Task<IActionResult> PlaceById(Guid id)
        {
            PlaceByIdDTO? dto = await _placeService.PlaceById(id);

            if (dto?.Id == Guid.Empty)
            {
                return View("Error", "Мястото не може да бъде намерено");
            }

            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new PlaceDTO()
            {
                Cities = (await _settlementService.GetCitiesByServicedRegions()).ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlaceDTO dto)
        {
            Guid photoBaseId = (await CreatePlacePhoto(dto)).Id;

            Guid placeGuid = await _placeService.Create(new()
            {
                Name = dto?.Place?.Name,
                Description = dto?.Place?.Description,
                GoogleMapsURL = dto?.Place?.GoogleMapsURL,
                CityId = dto.Place.CityId,
                CreatedById = dto?.Place?.CreatedById,
                CreatedOn = DateTime.Now,
                IsPopular = dto.Place.IsPopular,
                PhotoBaseId = photoBaseId
            });
            
            if (placeGuid != Guid.Empty)
            {
                PlaceByIdDTO? createdPlace = await _placeService.PlaceById(placeGuid);

                if(createdPlace?.Id == Guid.Empty)
                {
                    return View("Error", "An error occured while creating the place");
                }

                CreatePlacePhotoFile(createdPlace, ConvertFormFileToByteArray(dto.File));
                return RedirectToAction(nameof(PlaceById), new { id = placeGuid, isUpdate = false });
            }

            return View("Error", "An error occured while updating the place");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            PlaceByIdDTO? dto = await _placeService.PlaceById(id);

            if (dto == null)
            {
                return View("Error", "Мястото не може да бъде намерено");
            }

            return View(new PlaceDTO()
            {
                //Place = dto,
                Cities = (await _settlementService.GetCitiesByServicedRegions()).ToList(),
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PlaceDTO dto)
        {
            Guid placeId = await _placeService.Update(dto.Place);

            if (placeId == Guid.Empty)
            {
                return View("Error", "An error occured while updating the place");
            }

            PlaceByIdDTO? placeByIdDTO = await _placeService.PlaceById(placeId);

            if(placeByIdDTO?.Id == Guid.Empty)
            {
                return View("Error", "An error occured while updating the place");
            }
            
            //update place photo if file is not null
            if (dto.File != null)
            {
                PhotoBase createdPhoto = dto.Place.PhotoBase = await CreatePlacePhoto(dto);
                bool result = await _placeService.UpdatePhotoId(placeId, createdPhoto.Id);

                if (!result)
                {
                    return View("Error", "An error occured while updating the place");
                }

                CreatePlacePhotoFile(placeByIdDTO ?? new(), ConvertFormFileToByteArray(dto.File));
            }
            
            if (placeId != Guid.Empty)
            {
                return RedirectToAction(nameof(PlaceById), new{ id = placeId, isUpdate = false });
            }

            return View("Error", "An error occured while updating the place");
        }

        private async Task<PhotoBase> CreatePlacePhoto(PlaceDTO dto)
        {
            string resourcesPath = Path.Combine("resources", "places");

            PhotoBase photoBase = new()
            {
                FileName = dto?.File?.FileName,
                FilePath = $"{Path.Combine(resourcesPath, dto?.File?.FileName)}",
                FileType = dto.File.ContentType,
                IsDeleted = false,
            };


            return await _photoService.Create(photoBase, GetUserId());
        }

        private void CreatePlacePhotoFile(PlaceByIdDTO place, byte[] fileData)
        {
            byte[] resized = _photoResizer.Resize(fileData, PhotoSize.Small);
            place.PhotoBase.FilePath = Path.Combine(_webHostEnvironment.WebRootPath, place.PhotoBase.FilePath);

            _fileService.CreatePlacePhotoFile(new CreatePlacePhotoFileDTO()
            {
                PlaceId = place!.Id,
                PhotoBase = place.PhotoBase,
                FileData = resized
            });
        }

        private static byte[] ConvertFormFileToByteArray(IFormFile formFile)
        {
            using var stream = new MemoryStream();
            formFile.CopyTo(stream);
            return stream.ToArray();
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                throw new NullReferenceException("User not logged in");
        }
    }
}
