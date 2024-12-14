using OwlStock.Domain.Enumerations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class MyPhotoShootsDTO
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal? Price { get; set; }
        public PhotoShootType PhotoShootType { get; set; }
        public PhotoDeliveryMethod? PhotoDeliveryMethod { get; set; }
        public PhotoshootStatus? PhotoshootStatus { get; set; }
        public string? ReservationFor { get; set; }
    }
}
