using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class GiftCardService : IGiftCardService
    {
        private OwlStockDbContext _context;
        private ILogger<GiftCardService> _logger;

        public GiftCardService(OwlStockDbContext context, ILogger<GiftCardService> logger) 
        {
            _context = context ?? new OwlStockDbContext();
            _logger = logger;
        }

        public async Task<bool> Create(GiftCard giftCard)
        {
            if(giftCard == null)
            {
                _logger.LogError($"{nameof(giftCard)} is null at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(Create)}");
                return false;
            }

            if (giftCard.Receiver.IsNullOrEmpty())
            {
                _logger.LogError($"${nameof(giftCard.Receiver)} is null or empty at {DateTime.UtcNow} in {nameof(GiftCardService)}, {nameof(Create)}");
                return false;
            }

            try
            {
                await _context.AddAsync(giftCard);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }
    }
}
