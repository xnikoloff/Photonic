using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs.HomePage
{
    public class HomePageDTO
    {
        public string? Photo { get; set; }
        public IEnumerable<DynamicContent>? DynamicContents { get; set; }
        public IEnumerable<Testimony>? Testimonies { get; set; }
    }
}
