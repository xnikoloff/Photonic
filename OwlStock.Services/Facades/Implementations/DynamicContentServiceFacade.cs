using OwlStock.Services.DTOs.DynamicContents;
using OwlStock.Services.Facades.Interfaces;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services.Facades.Implementations
{
    public class DynamicContentServiceFacade : IDynamicContentServiceFacade
    {
        private readonly IDynamicContentService _dynamicContentService;
        private readonly ICalculationsService _calculationsService;
        private readonly IFileService _fileService;

        public DynamicContentServiceFacade(IDynamicContentService dynamicContentService, ICalculationsService calculationsService, IFileService fileService)
        {
            _dynamicContentService = dynamicContentService;
            _calculationsService = calculationsService;
            _fileService = fileService;
        }

        public async Task<bool> Create(CreateDynamicContentDTO dto)
        {
            dto!.DynamicContent!.ReadingTime = _calculationsService.CalculateReadingTime(dto.DynamicContent.Content);

            bool resultIFormFile = await _fileService.CreateIFormFile(dto!.Image, dto!.WebRootPath);

            if (!resultIFormFile)
            {
                return false;
            }

            bool resultContent = await _dynamicContentService.Create(dto);

            if (!resultContent)
            {
                return false;
            }

            return true;
        }
    }
}
