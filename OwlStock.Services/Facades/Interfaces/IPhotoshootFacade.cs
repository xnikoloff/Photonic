using OwlStock.Services.DTOs.PhotoShoot;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IPhotoshootFacade
    {
        Task<bool> ReservePhotoshoot(CreateRegularPhotoShootDTO dto);
        Task<bool> ReserveSmallProductPhotoshoot(CreateSmallProductPhotoshootDTO dto);
    }
}
