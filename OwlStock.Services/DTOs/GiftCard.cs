using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs
{
    public class CreateGiftCardDTO
    {
        public GiftCard? GiftCard { get; set; }
        public string? ReCaptchaToken { get; set; }
    }
}
