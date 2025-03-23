using OwlStock.Services.DTOs.PhotoShoot;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IPhotoshootFacade
    {
        Task<bool> ReservePhotoshoot(CreatePhotoShootDTO dto);
    }
}
