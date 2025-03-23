namespace OwlStock.Services.DTOs.Place
{
    public class CreatePlaceDTO
    {
        public string? Name { get; set; }
        public string? GoogleMapsURL { get; set; }
        public bool IsPopular { get; set; }
        public int CityId { get; set; }
        public string? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsNewPlace { get; set; }
    }
}
