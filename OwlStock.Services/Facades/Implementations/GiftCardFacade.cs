using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure.Common.EmailTemplates.GiftCard;
using OwlStock.Infrastructure.Migrations;
using OwlStock.Services.DTOs.GiftCard;
using OwlStock.Services.Facades.Interfaces;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services.Facades.Implementations
{
    public class GiftCardFacade : IGiftCardFacade
    {
        private readonly IGiftCardService _giftCardService;
        private readonly ICalculationsService _calculationsService;
        private readonly IEmailService _emailService;

        public GiftCardFacade(IGiftCardService giftCardService, ICalculationsService calculationsService, IEmailService emailService)
        {
            _giftCardService = giftCardService;
            _calculationsService = calculationsService;
            _emailService = emailService;
        }

        public async Task<Domain.Entities.GiftCard> Create(CreateGiftCardDTO? dto, string userEmail)
        {
            dto!.Price = _calculationsService.CalculatePhotoshootPrice(dto.PhotoShootType, 0, 0);
            Domain.Entities.GiftCard giftCard = await _giftCardService.Create(dto);

            GiftCardEmailTemplateDTO emailDto = new()
            {
                Id = giftCard.Id,
                Topic = "Нов подаръчен ваучер",
                Price = giftCard.Price.ToString(),
                PhotoShootType = giftCard.PhotoShootType,
                EmailTemplate = EmailTemplate.CreateGiftCard,
                GiftCardNumber = giftCard.GiftCardNumber,
                Recipient = userEmail,
            };

            await _emailService.Send(emailDto);

            return giftCard;
        }

        public async Task<bool> ChangeStatus(Guid id, GiftCardStatus status, string userId)
        {
            bool isChangeSuccessful = await _giftCardService.ChangeStatus(id, status, userId);

            if (!isChangeSuccessful)
            {
                return false;
            }

            Domain.Entities.GiftCard giftCard = await _giftCardService.GetById(id);

            GiftCardEmailTemplateDTO emailDto = new()
            {
                Id = id,
                Topic = "Активиран подаръчен ваучер",
                Price = giftCard.Price.ToString(),
                PhotoShootType = giftCard.PhotoShootType,
                EmailTemplate = EmailTemplate.ActivateGiftCard,
                GiftCardNumber = giftCard.GiftCardNumber,
                Recipient = giftCard?.IdentityUser?.Email,
            };

            bool isEmailSent = await _emailService.Send(emailDto);

            if (!isEmailSent)
            {
                return false;
            }

            return true;
        }
    }
}
