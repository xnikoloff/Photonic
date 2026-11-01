using OwlStock.Domain.Enumerations;

namespace OwlStock.Services.DTOs.GiftCard
{
    public class MyGiftCardDTO
    {
        public Guid Id { get; set; }
        public string Receiver { get; set; }
        public string Price { get; set; }
        public GiftCardStatus Status { get; set; }
        public PhotoShootType PhotoshootType { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
