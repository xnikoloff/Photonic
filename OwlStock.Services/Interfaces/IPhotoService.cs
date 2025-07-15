using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs;

namespace OwlStock.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoByIdDTO> GetById(Guid id);
        Task<PhotoBase> GetPhotoBaseById(Guid id);
        Task<IEnumerable<Gear>> GetPhotoGears();
        Task<PhotoBase> Create(PhotoBase? photo, string userId);
        Task<bool> Delete(PhotoBase photo);
        Task<bool> ChangeDownloadPermissions(Guid id);
    }
}
