using OwlStock.Domain.Enumerations;

namespace OwlStock.Services.DTOs.GiftCard
{
    public class CreateGiftCardDTO
    {
        public string? Receiver { get; set; }
        public PhotoShootType PhotoShootType { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? GiftCardNumber { get; set; }
        public GiftCardStatus Status { get; set; }
        public string? IdentityUserId { get; set; }
    }
}
