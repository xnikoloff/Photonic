using OwlStock.Services.DTOs.DynamicContents;

namespace OwlStock.Services.Facades.Interfaces
{
    public interface IDynamicContentServiceFacade
    {
        Task<bool> Create(CreateDynamicContentDTO dto);
    }
}
