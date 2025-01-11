using OwlStock.Domain.Entities;

namespace OwlStock.Services.Interfaces
{
    public interface ITestimonyService
    {
        Task<Testimony> Create(Testimony testimony);
        Task<Testimony> Approve(Guid id);
        Task<Testimony> Hide(Guid id);
        Task<Testimony> Unhide(Guid id);
        Task<IEnumerable<Testimony>> GetLastFour();
        Task<IEnumerable<Testimony>> GetApproved();
        Task<IEnumerable<Testimony>> GetHidden();
        Task<IEnumerable<Testimony>> GetNew();
        Task<IEnumerable<Testimony>> GetUnhidden();
    }
}
