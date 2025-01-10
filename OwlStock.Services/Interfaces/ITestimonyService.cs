using OwlStock.Domain.Entities;

namespace OwlStock.Services.Interfaces
{
    public interface ITestimonyService
    {
        Task<Testimony> Create(Testimony testimony);
        Task<IEnumerable<Testimony>> GetLastFour();
        Task<Testimony> Approve(Guid id);
        Task<Testimony> Hide(Guid id);
    }
}
