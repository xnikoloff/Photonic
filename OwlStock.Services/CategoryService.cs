using Microsoft.Extensions.Logging;
using OwlStock.Domain.Entities;
using OwlStock.Domain.Enumerations;
using OwlStock.Infrastructure;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly OwlStockDbContext _context;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(OwlStockDbContext context, ILogger<CategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Create(IEnumerable<Category> categories, Guid photoId)
        {
            IEnumerable<PhotoCategory> photoCategories = BuildPhotoCateoriesList(categories, photoId);

            if(_context.PhotosCategories is null)
            {
                throw new NullReferenceException($"{nameof(_context.PhotosCategories)} is null");
            }

            try
            {
                await _context.PhotosCategories.AddRangeAsync(photoCategories);
                await _context.SaveChangesAsync();
                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }

        private static IEnumerable<PhotoCategory> BuildPhotoCateoriesList(IEnumerable<Category> categories, Guid photoId)
        {
            List<PhotoCategory> photoCategories = new();

            foreach (Category category in categories)
            {
                PhotoCategory photoCategory = new()
                {
                    GalleryPhotoId = photoId,
                    Category = category

                };

                photoCategories.Add(photoCategory);
            }

            return photoCategories;
        }
    }
}
