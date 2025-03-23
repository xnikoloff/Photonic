using OwlStock.Domain.Entities;

namespace OwlStock.Services.DTOs.Place
{
    public class PlaceByIdDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? PhotoFileName { get; set; }
        public PhotoBase PhotoBase { get; set; }
        public List<PhotoShootPhoto>? Photos { get; set; }
    }
}
