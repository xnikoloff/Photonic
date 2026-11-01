using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure;
using OwlStock.Infrastructure.Common.PdfTemplates.GiftCard;
using OwlStock.Services.DTOs.GiftCard;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services.Implementations
{
    public class GiftCardService : IGiftCardService
    {
        private PhotonicDbContext _context;
        private ICalculationsService _calculationsService;
        private ILogger<GiftCardService> _logger;

        public GiftCardService(PhotonicDbContext context, ILogger<GiftCardService> logger, ICalculationsService calculationsService) 
        {
            _context = context ?? new PhotonicDbContext();
            _calculationsService = calculationsService;
            _logger = logger;
        }

        public async Task<IEnumerable<GiftCard>> GetAll()
        {
            if (_context.GiftCards is null)
            {
                _logger.LogError($"{nameof(_context.GiftCards)} is null at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(GetAll)}");
                return new List<GiftCard>();
            }

            try
            {
                return await _context.GiftCards
                    .OrderByDescending(gf => gf.Id)
                    .ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new List<GiftCard>();
            }
        }

        public async Task<IEnumerable<MyGiftCardDTO>> GiftCardsByUser(string userId)
        {
            if (_context.GiftCards is null)
            {
                _logger.LogError($"{nameof(_context.GiftCards)} is null at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(GiftCardsByUser)}");
                return new List<MyGiftCardDTO>();
            }

            try
            {
                IEnumerable<MyGiftCardDTO> giftCards = await _context.GiftCards
                    .Where(gf => gf.IdentityUserId!.Equals(userId))
                    .Select(gf => new MyGiftCardDTO
                    {
                        Id = gf.Id,
                        CreatedOn = gf.CreatedOn,
                        PhotoshootType = gf.PhotoShootType,
                        Price = gf.Price.ToString(),
                        Receiver = gf.Receiver ?? "",
                        Status = gf.Status
                    })
                    .OrderByDescending(gf => gf.Id)
                    .ToListAsync();

                return giftCards;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new List<MyGiftCardDTO>();
            }
        }

        public async Task<GiftCard> GetById(Guid id)
        {
            if (_context.GiftCards is null)
            {
                _logger.LogError($"{nameof(_context.GiftCards)} is null at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(GetById)}");
                return new();
            }

            if(id == Guid.Empty)
            {
                _logger.LogError($"{nameof(id)} is empty at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(GetById)}");
                return new();
            }

            try
            {
               return await _context.GiftCards.FindAsync(id) ?? new GiftCard();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        public async Task<GiftCard> Create(CreateGiftCardDTO dto)
        {
            if(dto == null)
            {
                _logger.LogError($"{nameof(dto)} is null at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(Create)}");
                return new();
            }

            if (dto.Receiver.IsNullOrEmpty())
            {
                _logger.LogError($"${nameof(dto.Receiver)} is null or empty at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(Create)}");
                return new();
            }

            GiftCard giftCard = new()
            {
                Price = _calculationsService.CalculatePhotoshootPrice(dto.PhotoShootType, 0, 0),
                Receiver = dto.Receiver,
                IdentityUserId = dto.IdentityUserId,
                CreatedOn = DateTime.Now,
                GiftCardNumber = GenerateGiftCardNumber(dto.PhotoShootType),
                PhotoShootType = dto.PhotoShootType,
                Status = GiftCardStatus.New
            };

            try
            {
                await _context.AddAsync(giftCard);
                await _context.SaveChangesAsync();
                return giftCard;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        public async Task<bool> ChangeStatus(Guid id, GiftCardStatus status, string userId)
        {
            if (_context.GiftCards is null)
            {
                _logger.LogError($"{nameof(_context.GiftCards)} is null at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(GetById)}");
                return false;
            }

            if (id == Guid.Empty)
            {
                _logger.LogError($"{nameof(id)} is empty at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(GetById)}");
                return false;
            }

            if(status > 0)
            {
                try
                {
                    GiftCard? giftCard = await _context.GiftCards.FindAsync(id);

                    if (giftCard != null) 
                    {
                        giftCard.Status = status;
                        giftCard.UpdatedOn = DateTime.Now;
                        giftCard.UpdatedById = userId;
                        await _context.SaveChangesAsync();
                        return true;
                    }

                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Builds the HTML template for a GiftCard
        /// </summary>
        /// <param name="giftCard">GiftCard with the required data</param>
        /// <returns>HTML code as string</returns>
        public string GetHtmlTemplate(GiftCard giftCard)
        {
            GiftCardTemplateBaseDTO dto = new()
            {
                GiftCardNumber = giftCard.GiftCardNumber,
                Photoshoot = giftCard.PhotoShootType.ToString(),
                Receiver = giftCard.Receiver,
                ValidUntil = giftCard.CreatedOn.AddYears(1).ToString("dd.MM.yyyy")
            };

            return CreateGiftCardPdfTemplate.CreateGiftCard(dto);
           
        }
        
        private string GenerateGiftCardNumber(PhotoShootType photoShootType)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //generate three random numbers to get three random letters from the alphabet
            Random random = new();
            int randomNumber1 = random.Next(0, alphabet.Length);
            int randomNumber2 = random.Next(0, alphabet.Length);
            int randomNumber3 = random.Next(0, alphabet.Length);

            try
            {
                string number =
                    "GC-" +
                    DateTime.Now.Year.ToString()[2..] +
                    DateTime.Now.Month +
                    DateTime.Now.Day + "-" +
                    photoShootType.ToString()[..3].ToUpper() + "-" +
                    Guid.NewGuid().ToString().ToUpper()[..4] + "-" +
                    alphabet[randomNumber1] + alphabet[randomNumber2] + alphabet[randomNumber3];

                return number;
            }

            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return string.Empty;
            }
        }
    }
}
