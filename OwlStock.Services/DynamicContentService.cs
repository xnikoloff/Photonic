using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;
using OwlStock.Services.DTOs.DynamicContents;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class DynamicContentService : IDynamicContentService
    {
        private const int _visibleContent = 4;

        private readonly OwlStockDbContext _context;
        private readonly IFileService _fileService;
        private readonly ICalculationsService _calculationsService;

        public DynamicContentService(OwlStockDbContext context, IFileService fileService, ICalculationsService calculationsService)
        {
            _context = context;
            _fileService = fileService;
            _calculationsService = calculationsService;

        }

        public async Task<DynamicContent> Create(CreateDynamicContentDTO dto)
        {
            if(_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            if (dto == null)
            {
                throw new NullReferenceException($"{nameof(dto)} is null");
            }

            if (dto.DynamicContent == null)
            {
                throw new NullReferenceException($"{nameof(dto.DynamicContent)} is null");
            }

            if (dto.DynamicContent.Content == null)
            {
                throw new NullReferenceException($"{nameof(dto.DynamicContent)} is null");
            }

            if (dto.Image == null)
            {
                throw new NullReferenceException($"{nameof(dto.Image)} is null");
            }

            if (dto.WebRootPath == null)
            {
                throw new NullReferenceException($"{nameof(dto.WebRootPath)} is null");
            }

            if (!dto.NewCategoryName.IsNullOrEmpty())
            {
                DynamicContentCategory category = new()
                {
                    CreatedById = dto.DynamicContent.CreatedById,
                    CreatedOn = DateTime.Now,
                    Name = dto.NewCategoryName
                };

                await _context.AddAsync(category);
                await _context.SaveChangesAsync();

                dto.DynamicContent.DynamicContentCategoryId = category.Id;

            }
            else
            {
                dto.DynamicContent.DynamicContentCategoryId = dto.SelectedCategoryId;
            }

            dto.DynamicContent.ImageName = dto?.Image?.FileName;
            dto!.DynamicContent.ReadingTime = _calculationsService.CalculateReadingTime(dto.DynamicContent.Content);
            dto.DynamicContent.CreatedOn = DateTime.Now;

            await _context.AddAsync(dto!.DynamicContent);
            await _context.SaveChangesAsync();
            await _fileService.CreateIFormFile(dto!.Image, dto!.WebRootPath);

            return await _context.DynamicContents
                .OrderByDescending(dc => dc.Id)
                .FirstOrDefaultAsync() ?? 
                    throw new NullReferenceException($"Cannot find DynamicContent");
        }

        public async Task Delete(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            DynamicContent dynamicContent = await _context.DynamicContents.FindAsync(id) ??
                throw new NullReferenceException($"DynamicContent with id {id} does not exists");

            _context.DynamicContents.Remove(dynamicContent);
            await _context.SaveChangesAsync();
        }

        public async Task<DynamicContent> GetById(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            return await _context.DynamicContents
                .Include(dc => dc.DynamicContentCategories)
                .ThenInclude(dcc => dcc.DynamicContents)
                .Where(dc => dc.Id == id)
                .FirstOrDefaultAsync() ?? 
                throw new NullReferenceException($"DynamicContent with id {id} does not exists");
        }

        public async Task<AllDynamicContentsDTO> GetAll()
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            if (_context.DynamicContentCategories is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            List<DynamicContent>? dynamicContents = await _context.DynamicContents
                .Include(dc => dc.CreatedBy)
                .Include(dc => dc.DynamicContentCategories)
                .ToListAsync();

            List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

            return new AllDynamicContentsDTO()
            {
                DynamicContents = dynamicContents,
                DynamicContentCategories = dynamicContentCategories
            };
        }

        public async Task<AllDynamicContentsDTO> GetAllByCategory(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            if (_context.DynamicContentCategories is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            List<DynamicContent>? dynamicContents = await _context.DynamicContents
               .Include(dc => dc.CreatedBy)
               .Include(dc => dc.DynamicContentCategories)
               .Where(dc => dc.DynamicContentCategories.Id == id)
               .ToListAsync();

            List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

            return new AllDynamicContentsDTO()
            {
                DynamicContents = dynamicContents,
                DynamicContentCategories = dynamicContentCategories
            };
        }

        public async Task<AllDynamicContentsDTO> GetAllByPage(int pageNumber)
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            if (_context.DynamicContentCategories is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            if (pageNumber <= 0) 
            { 
                throw new ArgumentOutOfRangeException(nameof(pageNumber));
            }

            List<DynamicContent> dynamicContents = await _context.DynamicContents
                .Where(dc => dc.IsVisible)
                .Include (dc => dc.CreatedBy)
                .Skip((pageNumber * _visibleContent) - _visibleContent)
                .Take(_visibleContent)
                .ToListAsync();

            List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

            
            return new AllDynamicContentsDTO()
            {
                DynamicContents = dynamicContents,
                DynamicContentCategories = dynamicContentCategories,
                PagesCount = await CalculatePagesNumber()
            };
        }

        public async Task<IEnumerable<DynamicContent>> GetLastFour()
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            return await _context.DynamicContents
                .Where(dc => dc.ShowInTopPosition && dc.IsVisible)
                .Include(dc => dc.DynamicContentCategories)
                .OrderBy(dc => dc.Id)
                .Take(4)
                .ToListAsync();
        }

        public async Task<IEnumerable<DynamicContentCategory>> GetAllDynamicContentCategories()
        {
            if (_context.DynamicContentCategories is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContentCategories)} is null");
            }

            return await _context.DynamicContentCategories.ToListAsync();
        }

        private async Task<int> CalculatePagesNumber()
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContentCategories)} is null");
            }

            double total = await _context.DynamicContents.CountAsync();

            if (total == 0)
            {
                return 0;
            }

            int result = (int)Math.Ceiling(total / _visibleContent);

            return result;
        }
    }
}
