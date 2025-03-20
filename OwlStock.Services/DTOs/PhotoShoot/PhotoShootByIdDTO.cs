using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;

namespace OwlStock.Services.DTOs.PhotoShoot
{
    public class PhotoShootByIdDTO
    {
        public Guid Id { get; set; }
        public string? PhotoshootNumber { get; set; }
        public string? PersonFullName { get; set; }
        public string? PersonPhone { get; set; }
        public PhotoshootStatus? Status { get; set; }
        public DateTime ReservationDate { get; set; }
        public PhotoShootType PhotoShootType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? PhotoShootTypeDescription { get; set; }
        public bool IsPopularPlaceSelected { get; set; }
        public string? Place { get; set; }
        public string? Settlement { get; set; }
        public string? Region { get; set; }
        public PhotoDeliveryMethod? PhotoDeliveryMethod { get; set; }
        public string? PhotoDeliveryAddress { get; set; }
        public decimal Price { get; set; }
        public bool TransportCustomer { get; set; }
        public string? PickUpAddress { get; set; }
        public bool IsSmallProduct { get; set; }
        public string? IdentityUserId { get; set; }
        public ICollection<PhotoShootPhoto>? PhotoShootPhotos { get; set; }
    }
}
