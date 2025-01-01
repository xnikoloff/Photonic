using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs;

namespace OwlStock.Services.Interfaces
{
    public interface IDynamicContentService
    {
        Task<DynamicContent> GetById(Guid id);
        Task<IEnumerable<DynamicContent>> GetAll();
        Task<IEnumerable<DynamicContent>> GetAllByCategory(Guid id);
        Task<IEnumerable<DynamicContent>> GetLastFour();
        Task<IEnumerable<DynamicContentCategory>> GetAllDynamicContentCategories();
        Task<DynamicContent> Create(CreateDynamicContentDTO dto);
        Task Delete(Guid id);
    }
}
