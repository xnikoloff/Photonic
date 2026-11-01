using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Services.DTOs.GiftCard;

namespace OwlStock.Services.Interfaces
{
    public interface IGiftCardService
    {
        Task<IEnumerable<GiftCard>> GetAll();
        Task<IEnumerable<MyGiftCardDTO>> GiftCardsByUser(string userId);
        Task<GiftCard> GetById(Guid id);
        Task<GiftCard> Create(CreateGiftCardDTO dto);
        Task<bool> ChangeStatus(Guid id, GiftCardStatus status, string userId);
        string GetHtmlTemplate(GiftCard giftCard);
    }
}
