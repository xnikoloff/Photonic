using OwlStock.Domain.Enumerations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class ChangePhotoshootStatusDTO
    {
        public Guid Id { get; set; }
        public string? PersonEmail { get; set; }
    }
}
