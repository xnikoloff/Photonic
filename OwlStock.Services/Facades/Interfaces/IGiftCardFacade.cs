using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs.GiftCard;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IGiftCardFacade
    {
        Task<GiftCard> Create(CreateGiftCardDTO? dto, string userEmail);
        Task<bool> ChangeStatus(Guid id, GiftCardStatus status, string userId);
    }
}
