using OwlStock.Domain.Entities;
using OwlStock.Services.DTOs.DynamicContents;

namespace OwlStock.Services.Interfaces
{
    public interface IDynamicContentService
    {
        Task<DynamicContent> GetById(Guid id);
        Task<AllDynamicContentsDTO> GetAll();
        Task<AllDynamicContentsDTO> GetAllByCategory(Guid id);
        Task<AllDynamicContentsDTO> GetAllByPage(int pageNumber);
        Task<IEnumerable<DynamicContent>> GetLastFour();
        Task<IEnumerable<DynamicContentCategory>> GetAllDynamicContentCategories();
        Task<DynamicContent> Create(CreateDynamicContentDTO dto);
        Task Delete(Guid id);
    }
}
