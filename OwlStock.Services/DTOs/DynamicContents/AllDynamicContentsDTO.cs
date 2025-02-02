using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs.DynamicContents
{
    public class AllDynamicContentsDTO
    {
        public List<DynamicContent>? DynamicContents { get; set; }
        public List<DynamicContentCategory>? DynamicContentCategories { get; set; }
        public int PagesCount { get; set; }
    }
}
