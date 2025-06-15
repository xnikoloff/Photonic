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
                throw new ArgumentNullException($"{nameof(announcement)}");
            }

            if (announcement.Content.IsNullOrEmpty())
            {
                throw new NullReferenceException($"{nameof(announcement.Content)} is null or empty");
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
                throw new NullReferenceException($"{nameof(_context.Announcements)} is null");
            }

            if (announcement == null)
            {
                throw new ArgumentNullException($"{nameof(announcement)}");
            }

            if (announcement.Content.IsNullOrEmpty())
            {
                throw new NullReferenceException($"{nameof(announcement.Content)} is null or empty");
            }

            if (announcement.Id == Guid.Empty)
            {
                throw new NullReferenceException($"{nameof(announcement.Id)} is null or empty");
            }

            try
            {
                Announcement existingAnnouncement = await _context.Announcements.FindAsync(announcement.Id) ??
                throw new NullReferenceException($"{nameof(announcement)} with id {announcement.Id} cannot be found");

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
                throw new NullReferenceException($"{nameof(_context.Announcements)} is null");
            }

            return await _context.Announcements.ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> GetActive()
        {
            if (_context.Announcements is null)
            {
                throw new NullReferenceException($"{nameof(_context.Announcements)} is null");
            }

            return await _context.Announcements
                .Where(a => a.IsActive)
                .ToListAsync();
        }

        public async Task<Announcement> GetById(Guid id)
        {
            if (_context.Announcements is null)
            {
                throw new NullReferenceException($"{nameof(_context.Announcements)} is null");
            }

            if (id == Guid.Empty)
            {
                throw new NullReferenceException($"{nameof(id)} is null or empty");
            }

            Announcement? announcement = await _context.Announcements.FindAsync(id);
            
            return announcement ?? new Announcement();
        }

        public async Task<bool> ManageAnnouncementsVisibility(Guid id, string userId)
        {
            if(_context.Announcements is null)
            {
                throw new NullReferenceException($"{nameof(_context.Announcements)}");
            }

            if(id == Guid.Empty)
            {
                throw new ArgumentNullException($"{nameof(id)}");
            }

            try
            {
                Announcement announcement = await _context.Announcements.FindAsync(id) ??
                throw new NullReferenceException($"{nameof(announcement)} with id {id} cannot be found");

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
