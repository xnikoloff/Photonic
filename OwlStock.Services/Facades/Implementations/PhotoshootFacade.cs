using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure.Common.EmailTemplates.Account;
using OwlStock.Infrastructure.Common.EmailTemplates.PhotoShoot;
using OwlStock.Services.DTOs.PhotoShoot;
using OwlStock.Services.DTOs.Place;
using OwlStock.Services.Facades.Interfaces;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services.Facades.Implementations
{
    public class PhotoshootFacade : IPhotoshootFacade
    {
        private readonly IAdministrationService _administrationService;
        private readonly IPlaceService _placeService;
        private readonly IPhotoShootService _photoShootService;
        private readonly ICalculationsService _calculationsService;
        private readonly IEmailService _emailService;

        public PhotoshootFacade(IAdministrationService administrationService, IPhotoShootService photoShootService, 
            IPlaceService placeService, IEmailService emailService, ICalculationsService calculationsService)
        {
            _administrationService = administrationService;
            _placeService = placeService;
            _photoShootService = photoShootService;
            _emailService = emailService;
            _calculationsService = calculationsService;
        }

        public async Task<bool> ReservePhotoshoot(CreatePhotoShootDTO dto)
        {
            bool isUserSuccessful = await HandleUser(dto);

            if (!isUserSuccessful)
            {
                return false;
            }

            //create place only when user has set a name for it
            //otherwise no new place should be created
            if (!dto.UserPlace.IsNullOrEmpty())
            {
                Guid placeGuid = await HandlePlace(new CreatePlaceDTO()
                {
                    IsPopular = true,
                    Name = dto.UserPlace,
                    GoogleMapsURL = dto.GoogleMapsLink,
                    CreatedById = dto.IdentityUserId
                });
                
                dto.PlaceId = placeGuid;
            }

            dto.Price = _calculationsService.CalculatePhotoshootPrice(dto.PhotoShootType, dto.FuelPrice);

            Guid photoshootGuid = await _photoShootService.Add(dto);

            if (photoshootGuid == Guid.Empty)
            {
                return false;
            }

            bool areEmailsHandled = await HandleEmails(dto, photoshootGuid);

            if (!areEmailsHandled)
            {
                return false;
            }
            
            return true;
        }

        private async Task<bool> HandleUser(CreatePhotoShootDTO dto)
        {
            //get user id and email
            IdentityUser user = new();

            if (!dto.IdentityUserId.IsNullOrEmpty())
            {
                await _administrationService.GetUserEmailByIdAsync(dto?.IdentityUserId ?? "");
            }


            else
            {
                user.Email = dto.PersonEmail;
                user.UserName = dto.PersonEmail;


                string password = await _administrationService.CreateUser(user);

                if (password.IsNullOrEmpty())
                {
                    return false;
                }

                //assign id of newly created user to the photoshoot DTO
                dto.IdentityUserId = user.Id;

                //assign password of newly created user to the photoshoot DTO
                dto.Password = password;

            }

            return true;
        }

        private async Task<Guid> HandlePlace(CreatePlaceDTO dto)
        {
            //Returns empty when no new place is created and that breaks the workflow
            Guid placeGuid = Guid.Empty;

            //Create new place if UserPlace is not null
            if (!string.IsNullOrEmpty(dto.Name))
            {
                placeGuid = await _placeService.Create(new()
                {
                    IsPopular = false,
                    Name = dto.Name,
                    GoogleMapsURL = dto.GoogleMapsURL,
                    CreatedById = dto.CreatedById
                });
            }

            return placeGuid;
        }

        private async Task<bool> HandleEmails(CreatePhotoShootDTO dto, Guid photoshootGuid)
        {
            PhotoShootEmailTemplateDTO emailDto = new()
            {
                Date = new DateTime(dto.ReservationDate.Year, dto.ReservationDate.Month, dto.ReservationDate.Day, dto.ReservationTime.Hour, dto.ReservationTime.Minute, 0),
                Topic = "Успешна резервация",
                Recipient = dto.PersonEmail,
                Type = dto.PhotoShootType,
                PersonFullName = dto.PersonFirstName + " " + dto.PersonLastName,
                EmailTemplate = EmailTemplate.CreatePhotoShoot,
                PhotoShootId = photoshootGuid
            };

            bool isPhotoshootEmailSent = await _emailService.Send(emailDto);

            if (!isPhotoshootEmailSent)
            {
                return false;
            }

            if (!dto.Password.IsNullOrEmpty())
            {
                CreateAccountEmailTemplateDTO accountEmailDTO = new()
                {
                    Password = dto.Password,
                    EmailTemplate = EmailTemplate.CreateAccount,
                    Topic = "Създадохме вашия профил",
                    Recipient = dto.PersonEmail
                };

                bool isAccountEmailSent = await _emailService.Send(accountEmailDTO);

                if (!isAccountEmailSent)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
