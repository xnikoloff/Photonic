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
        Task<AllDynamicContentsDTO> GetAllDeleted();
        Task<IEnumerable<DynamicContent>> GetTopContent();
        Task<IEnumerable<DynamicContentCategory>> GetAllDynamicContentCategories();
        Task<bool> Create(CreateDynamicContentDTO dto);
        Task<bool> Delete(Guid id);
        Task<bool> Recover(Guid id);
    }
}
