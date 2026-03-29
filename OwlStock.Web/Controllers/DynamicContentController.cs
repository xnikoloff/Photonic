using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.DynamicContents;
using OwlStock.Services.Facades.Interfaces;
using OwlStock.Services.Interfaces;
using System.Security.Claims;

namespace OwlStock.Web.Controllers
{
    [Route("blog")]
    public class DynamicContentController : Controller
    {
        private readonly IDynamicContentService _dynamicContentService;
        private readonly IDynamicContentServiceFacade __dynamicContentServiceFacade;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DynamicContentController(IDynamicContentService dynamicContentService, IDynamicContentServiceFacade dynamicContentServiceFacade, IWebHostEnvironment webHostEnvironment)
        {
            _dynamicContentService = dynamicContentService;
            __dynamicContentServiceFacade = dynamicContentServiceFacade;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("statiya")]
        public async Task<IActionResult> Content(Guid id)
        {
            DynamicContent content = await _dynamicContentService.GetById(id);

            if (content.Id == Guid.Empty)
            {
                return View("Error", "Не успяхме да намерим съдържанието, която търсите");
            }

            return View(content);
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            return View(await _dynamicContentService.GetAll());
        }

        [HttpGet("allByPage")]
        public async Task<IActionResult> AllByPage(int pageNumber = 1)
        {
            ViewData["PageNumber"] = pageNumber;
            var all = await _dynamicContentService.GetAllByPage(pageNumber);

            return View(nameof(Index), all);
        }

        [HttpGet("allByCategory")]
        public async Task<IActionResult> AllByCategory(Guid id)
        {
            AllDynamicContentsDTO all = await _dynamicContentService.GetAllByCategory(id);

            if (all.DynamicContents == null || all.DynamicContentCategories == null)
            {
                return View("Error", "Опитайте пак по-късно");
            }

            return View(nameof(Index), all);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("allDeleted")]
        public async Task<IActionResult> AllDeleted(Guid id)
        {
            AllDynamicContentsDTO all = await _dynamicContentService.GetAllDeleted();

            if (all.DynamicContents == null || all.DynamicContentCategories == null)
            {
                return View("Error", "Опитайте пак по-късно");
            }

            return View(nameof(Index), all);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create()
        {
            List<DynamicContentCategory> categories =
                (await _dynamicContentService.GetAllDynamicContentCategories()).ToList();

            return View(new CreateDynamicContentDTO()
            {
                DynamicContentCategories = categories
            });
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDynamicContentDTO dto)
        {
            dto.WebRootPath = _webHostEnvironment.WebRootPath;
            dto.DynamicContent.CreatedById = User.FindFirstValue(ClaimTypes.NameIdentifier) ??
                throw new NullReferenceException("User not logged in");

            bool isSuccessful = await __dynamicContentServiceFacade.Create(dto);

            if (!isSuccessful)
            {
                return View("Error", "An error occured while creating the dynamic content. See the log for details");
            }
            return RedirectToAction(nameof(AllByPage));
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isSuccessful = await _dynamicContentService.Delete(id);    

            if (!isSuccessful)
            {
                return View("Error", "An error occured while deleting the dynamic content. See the log for details");
            }

            return RedirectToAction(nameof(AllByPage));
        }

        [HttpGet("recover")]
        public async Task<IActionResult> Recover(Guid id)
        {
            bool isSuccessful = await _dynamicContentService.Recover(id);

            if (!isSuccessful)
            {
                return View("Error", "An error occured while recovering the dynamic content. See the log for details");
            }

            return RedirectToAction(nameof(AllByPage));
        }

        [HttpGet("allCategories")]
        public async Task<IActionResult> AllCategories()
        {
            return View(await _dynamicContentService.GetAllDynamicContentCategories());
        }

        [HttpGet("createCategory")]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost("createCategory")]
        public async Task<IActionResult> CreateCategory(DynamicContentCategory category)
        {
            bool result = await _dynamicContentService.CreateCategory(category);

            if (result)
            {
                return RedirectToAction(nameof(AllCategories));
            }

            else
            {
                return View("Error", "Cannot create category");
            }
        }
    }
}
