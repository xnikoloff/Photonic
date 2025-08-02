using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.Common.HelperClasses;
using OwlStock.Services.DTOs.PhotoShoot;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IPhotoshootFacade
    {
        Task<bool> ReservePhotoshoot(CreateRegularPhotoShootDTO dto);
        Task<bool> ReserveSmallProductPhotoshoot(CreateSmallProductPhotoshootDTO dto);
        Task<bool> UpdatePhotoshoot(UpdatePhotoShootDTO dto);
        Task<UpdatePhotoShootDTO> GetDataForUpdate(Guid id  );
        Task<Dictionary<DateOnly, IEnumerable<TimeSlot>>> GetPhotoShootsCalendar();
        Task<IEnumerable<SetReservedDateDTO>> GetCalendarWithStatus();
        Task<bool> ChangeStatus(Guid id, PhotoshootStatus status);
        Task<IEnumerable<WorkingTime>> GetWorkingTime();
    }
}
