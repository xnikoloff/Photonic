using OwlStock.Domain.Entities;
using System.Drawing;

namespace OwlStock.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<bool> Create(Announcement announcement, string userId);
        Task<bool> Update(Announcement announcement, string userId);
        Task<IEnumerable<Announcement>> GetAll();
        Task<IEnumerable<Announcement>> GetActive();
        Task<Announcement> GetById(Guid id);
        Task<bool> ManageAnnouncementsVisibility(Guid id, string userId);
    }
}
