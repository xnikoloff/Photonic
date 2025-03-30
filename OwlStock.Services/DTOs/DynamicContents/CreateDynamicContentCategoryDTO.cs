namespace OwlStock.Services.DTOs.DynamicContents
{
    internal class CreateDynamicContentCategoryDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedById { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
