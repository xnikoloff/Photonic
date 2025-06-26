using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly OwlStockDbContext _context;
        private readonly ILogger<AnnouncementService> _logger;

        public AnnouncementService(OwlStockDbContext context, ILogger<AnnouncementService> logger)
        {   
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Create(Announcement announcement, string usedId)
        {
            if (announcement == null)
            {
                _logger.LogError($"Announcement is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(Create)}");
                return false;
            }

            if (announcement.Content.IsNullOrEmpty())
            {
                _logger.LogError($"Announcement content is null or empty at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(Create)}");
                return false;
            }

            try
            {
                announcement.CreatedOn = DateTime.Now;
                announcement.CreatedById = usedId;
                announcement.IsActive = true;

                await _context.AddAsync(announcement);
                await _context.SaveChangesAsync();

                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }


        }

        public async Task<bool> Update(Announcement announcement, string userId)
        {
            if (_context.Announcements is null)
            {
                _logger.LogError($"{nameof(_context.Announcements)} is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(Update)}");
                return false;
            }

            if (announcement == null)
            {
                _logger.LogError($"{nameof(announcement)} is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(Update)}");
                return false;
            }

            if (announcement.Content.IsNullOrEmpty())
            {
                _logger.LogError($"{nameof(announcement.Content)} is null or empty at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(Update)}");
                return false;
            }

            if (announcement.Id == Guid.Empty)
            {
                _logger.LogError($"{nameof(announcement.Id)} is null or empty at {DateTime.UtcNow}");
                return false;
            }

            try
            {
                Announcement? existingAnnouncement = await _context.Announcements.FindAsync(announcement.Id);
                
                if (existingAnnouncement == null)
                {
                    _logger.LogError($"Announcement with id {announcement.Id} not found at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(Update)}");
                    return false;
                }

                existingAnnouncement.Content = announcement.Content;
                existingAnnouncement.EditedOn = DateTime.Now;
                existingAnnouncement.EditedById = userId;

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }

        public async Task<IEnumerable<Announcement>> GetAll()
        {
            if(_context.Announcements is null)
            {
                _logger.LogError($"{nameof(_context.Announcements)} is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(GetAll)}");
                return Enumerable.Empty<Announcement>();
            }

            try
            {
                return await _context.Announcements.ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return Enumerable.Empty<Announcement>();
            }
        }

        public async Task<IEnumerable<Announcement>> GetActive()
        {
            if (_context.Announcements is null)
            {
                _logger.LogError($"{nameof(_context.Announcements)} is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(GetActive)}");
                return Enumerable.Empty<Announcement>();
            }

            try
            {
                return await _context.Announcements
                .Where(a => a.IsActive)
                .ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return Enumerable.Empty<Announcement>();
            }
        }

        public async Task<Announcement> GetById(Guid id)
        {
            if (_context.Announcements is null)
            {
                _logger.LogError($"{nameof(_context.Announcements)} is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(GetById)}");
                return new Announcement();
            }

            if (id == Guid.Empty)
            {
                _logger.LogError($"{nameof(id)} is null or empty at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(GetById)}");
                return new Announcement();
            }

            try
            {
                return await _context.Announcements.FindAsync(id) ?? new Announcement();
            }
            
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new Announcement();
            }
        }

        public async Task<bool> ManageAnnouncementsVisibility(Guid id, string userId)
        {
            if(_context.Announcements is null)
            {
                _logger.LogError($"{nameof(_context.Announcements)} is null at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(ManageAnnouncementsVisibility)}");
                return false;
            }

            if(id == Guid.Empty)
            {
                _logger.LogError($"{nameof(id)} is null or empty at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(ManageAnnouncementsVisibility)}");
                return false;
            }

            try
            {
                Announcement? announcement = await _context.Announcements.FindAsync(id);

                if(announcement == null)
                {
                    _logger.LogError($"Announcement with id {id} not found at {DateTime.UtcNow} in {nameof(AnnouncementService)}, {nameof(ManageAnnouncementsVisibility)}");
                    return false;
                }

                if (announcement.IsActive)
                {
                    announcement.IsActive = false;
                    announcement.HiddenOn = DateTime.Now;
                    announcement.HiddenById = userId;
                }

                else
                {
                    announcement.IsActive = true;
                    announcement.UnhiddenOn = DateTime.Now;
                    announcement.UnhiddenById = userId;
                }

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
