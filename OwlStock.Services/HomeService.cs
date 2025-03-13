using Microsoft.EntityFrameworkCore;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;
using OwlStock.Services.DTOs.HomePage;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class HomeService : IHomeService
    {
        private readonly IDynamicContentService _dynamicContentService;
        private readonly ITestimonyService _testimonyService;
        private readonly OwlStockDbContext _context;

        public HomeService(OwlStockDbContext context, IDynamicContentService dynamicContentService, ITestimonyService testimonyService)
        {
            _context = context;
            _dynamicContentService = dynamicContentService;
            _testimonyService = testimonyService;
        }

        public async Task<HomePageDTO> GetHomeData()
        {
            IEnumerable<DynamicContent> dynamicContents = await _dynamicContentService.GetTopContent();
            IEnumerable<Testimony> testimonies = await _testimonyService.GetLastFour();

            return new HomePageDTO()
            {
                Photo = await ChooseHomePagePhoto(),
                DynamicContents = dynamicContents,
                Testimonies = testimonies
            };
        }

        private async Task<string> ChooseHomePagePhoto()
        {
            if(_context.GalleryPhotos is null)
            {
                throw new NullReferenceException($"{nameof(_context.GalleryPhotos)} is null");
            }

            List<GalleryPhoto> photos = await _context.GalleryPhotos.ToListAsync();

            if(photos.Count == 0)
            {
                return string.Empty;
            }

            Random random = new();
            int randomNumber = random.Next(0, _context.GalleryPhotos.Count());

            return photos[randomNumber].FilePathSmall ?? throw new NullReferenceException($"FilePath is null");

        }
    }
}
