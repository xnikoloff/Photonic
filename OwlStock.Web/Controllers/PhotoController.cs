using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs;
using OwlStock.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.Photo;
using OwlStock.Services.Facades.Interfaces;

namespace OwlStock.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IPhotoFacade _photoFacade;
        private readonly IGalleryService _galleryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public PhotoController(IPhotoService photoService, IWebHostEnvironment webHostEnvironment, 
            IGalleryService galleryService, IPhotoFacade photoFacade)
        {
            _photoService = photoService;
            _photoFacade = photoFacade;
            _webHostEnvironment = webHostEnvironment;
            _galleryService = galleryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _galleryService.All());
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public async Task<IActionResult> All(List<GalleryPhoto>? photos = null)
        {
            return View(await _galleryService.All());
        }

        [HttpGet]
        public async Task<IActionResult> Portfolio(Category category)
        {
            ViewData["categoryDescription"] = category.ToString();
            return View(await _galleryService.BuildCategoriesGallery());
        }

        [HttpGet]
        public async Task<IActionResult> AllByTag(string tag)
        {
            ViewData["Title"] = "Търсене | " + tag;
            return View(nameof(All), await _galleryService.AllByTags(tag));
        }

        [HttpGet]
        public async Task<IActionResult> PhotoById(Guid id)
        {
            return View(await _photoService.GetById(id));
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGalleryPhotoDTO? dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if(dto is not null)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new NullReferenceException("User not signed in");
                
                if(dto.GalleryPhoto is null)
                {
                    ModelState.AddModelError(string.Empty, "Please provide a photo");
                    return View(dto);
                }

                if (dto.FormFile is null)
                {
                    ModelState.AddModelError(string.Empty, "Please upload a file");
                    return View(dto);
                }

                if (dto.Tags is null)
                {
                    ModelState.AddModelError(string.Empty, "Please add tags");
                    return View(dto);
                }

                dto.GalleryPhoto.FileName = dto.FormFile.FileName;
                dto.GalleryPhoto.FileType = dto.FormFile.ContentType;
                dto.GalleryPhoto.FilePath = Path.Combine(webRootPath, "resources/gallery-photos").Replace('\\', '/');

                using MemoryStream stream = new();
                dto.FormFile.CopyTo(stream);
                dto.GalleryPhoto.FileData = stream.ToArray();
                dto.GalleryPhoto.IdentityUserId = userId;

                bool result = await _photoFacade.Create(dto, userId);

                if(result)
                {
                    return RedirectToAction(nameof(All));
                }
                else
                {
                    return View("Error", "Неуспешно създаване на снимка");
                }
            }
            
            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(PhotoByIdDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(PhotoById), new { dto?.Photo?.Id });
            }

            if (dto is not null)
            {
                if (dto.Photo is null)
                {
                    throw new NullReferenceException($"{nameof(dto.Photo)} is null");
                }

                await _photoService.Delete(dto.Photo);

            }

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeDownloadPermissions(PhotoByIdDTO dto)
        {
            if(dto.Photo == null)
            {
                //return to All() if there is a problem with the model
                return await All();
            }

            if (dto.Photo.Id == default)
            {
                ModelState.AddModelError(string.Empty, "Incorrect Id");
                return await PhotoById(dto.Photo.Id);
            }

            bool result = await _photoService.ChangeDownloadPermissions(dto.Photo.Id);

            if (!result)
            {
                return View("Error", "Неуспешна промяна");
            }

            return await All();
        }
    }
}
