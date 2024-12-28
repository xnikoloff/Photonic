using Microsoft.AspNetCore.Http;
using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs
{
    public class CreateDynamicContentDTO
    {
        public DynamicContent? DynamicContent { get; set; }
        public IFormFile? Image { get; set; }
        public string? WebRootPath { get; set; }
        public Guid SelectedCategoryId { get; set; }
        public List<DynamicContentCategory>? DynamicContentCategories { get; set; }

        public string? NewCategoryName { get; set; }
    }
}
