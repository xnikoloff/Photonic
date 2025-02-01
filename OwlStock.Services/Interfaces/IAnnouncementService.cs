using OwlStock.Domain.Entities;
using System.Drawing;

namespace OwlStock.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<Announcement> Create(Announcement announcement, string userId);
        Task<Announcement> Update(Announcement announcement, string userId);
        Task<IEnumerable<Announcement>> GetAll();
        Task<IEnumerable<Announcement>> GetActive();
        Task<Announcement> GetById(Guid id);
        Task<Announcement> ManageAnnouncementsVisibility(Guid id, string userId);
    }
}
