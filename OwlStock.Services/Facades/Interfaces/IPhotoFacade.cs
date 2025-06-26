using OwlStock.Services.DTOs.Photo;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IPhotoFacade
    {
        Task<bool> Create(CreateGalleryPhotoDTO? dto, string userId);
    }
}
