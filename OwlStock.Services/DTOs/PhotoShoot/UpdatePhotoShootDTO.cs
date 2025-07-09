using OwlStock.Domain.Enumerations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class UpdatePhotoShootDTO
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime ReservationDate { get; set; }
        public bool IsDecidedByUs { get; set; }
        public string? UIC { get; set; }
        public decimal Price { get; set; }
        public bool DoNotUploadPhotos { get; set; }
        public PhotoDeliveryMethod? PhotoDeliveryMethod { get; set; }
        public string? PhotoDeliveryAddress { get; set; }
        public bool TransportCustomer { get; set; }
        public string? PickUpAddress { get; set; }
        public bool IsSmallProduct { get; set; }
    }
}
