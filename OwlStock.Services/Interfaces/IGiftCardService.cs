using OwlStock.Domain.Entities;

namespace OwlStock.Services.Interfaces
{
    public interface IGiftCardService
    {
        Task<bool> Create(GiftCard giftCard);
    }
}
