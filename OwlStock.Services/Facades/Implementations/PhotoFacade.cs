using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.Photo;
using OwlStock.Services.Facades.Interfaces;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services.Facades.Implementations
{
    public class PhotoFacade : IPhotoFacade
    {
        private readonly IPhotoService _photoService;
        private readonly IPhotoTagService _photoTagService;
        private readonly ICategoryService _categoryService;
        private readonly IFileService _fileService;

        public PhotoFacade(IPhotoService photoService, IPhotoTagService photoTagService, 
            ICategoryService categoryService, IFileService fileService)
        {
            _photoService = photoService;
            _photoTagService = photoTagService;
            _categoryService = categoryService;
            _fileService = fileService;
        }

        public async Task<bool> Create(CreateGalleryPhotoDTO? dto, string userId)
        {
            _fileService.CreatePhotoFile(dto.GalleryPhoto);

            PhotoBase photo = await _photoService.Create(dto.GalleryPhoto, userId);
            bool resultPhoto = await _categoryService.Create(dto.Categories, photo.Id);

            if (!resultPhoto)
            {
                return false;
            }

            bool resultTags = await _photoTagService.Add(dto.Tags, photo.Id);

            if (!resultTags)
            {
                return false;
            }

            return true;
        }
    }
}
