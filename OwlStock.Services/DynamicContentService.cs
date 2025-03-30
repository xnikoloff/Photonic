using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;
using OwlStock.Services.DTOs.DynamicContents;
using OwlStock.Services.Interfaces;

namespace OwlStock.Services
{
    public class DynamicContentService : IDynamicContentService
    {
        private const int _visibleContentByPage = 4;
        private const int _visibleTopContent = 3;

        private readonly OwlStockDbContext _context;
        private readonly ILogger<DynamicContentService> _logger;

        public DynamicContentService(OwlStockDbContext context, ILogger<DynamicContentService> logger)
        {
            _context = context;
            _logger = logger;

        }

        /// <summary>
        /// Creates new DynamicContentCategory if the name of the category is not null
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>If created, Id of the created DynamucContentCategory, else empty GUID</returns>
        private async Task<CreateDynamicContentCategoryDTO> CreateDynamicContentCategory(CreateDynamicContentCategoryDTO dto)
        {
            try
            {
                if (!dto.Name.IsNullOrEmpty())
                {
                    DynamicContentCategory category = new()
                    {
                        CreatedById = dto.CreatedById,
                        CreatedOn = DateTime.Now,
                        Name = dto.Name
                    };

                    await _context.DynamicContentCategories.AddAsync(category);
                    await _context.SaveChangesAsync();

                    dto.Id = category.Id;
                    dto.IsSuccessful = true;

                    return dto;
                }
                else
                {
                    dto.Id = Guid.Empty;
                    dto.IsSuccessful = true;
                    return dto;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                dto.IsSuccessful = false;
                return dto;
            }
        }

        public async Task<bool> Create(CreateDynamicContentDTO dto)
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

            CreateDynamicContentCategoryDTO categoryDTO = await CreateDynamicContentCategory(new()
            {
                CreatedById = dto.DynamicContent.CreatedById,
                Name = dto.NewCategoryName,
                
            });

            if (categoryDTO.IsSuccessful)
            {
                if (categoryDTO.Id != Guid.Empty)
                {
                    dto.DynamicContent.DynamicContentCategoryId = categoryDTO.Id;
                }

                else
                {
                    dto.DynamicContent.DynamicContentCategoryId = dto.SelectedCategoryId;
                }
            }

            else
            {
                return false;
            }

            dto.DynamicContent.ImageName = dto?.Image?.FileName;
            dto.DynamicContent.CreatedOn = DateTime.Now;
            
            await _context.AddAsync(dto!.DynamicContent);
            int result = await _context.SaveChangesAsync();
            
            if(result == 0)
            {
                return false;
            }

            return true;
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
                .Skip((pageNumber * _visibleContentByPage) - _visibleContentByPage)
                .Take(_visibleContentByPage)
                .ToListAsync();

            List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

            
            return new AllDynamicContentsDTO()
            {
                DynamicContents = dynamicContents,
                DynamicContentCategories = dynamicContentCategories,
                PagesCount = await CalculatePagesNumber()
            };
        }

        public async Task<IEnumerable<DynamicContent>> GetTopContent()
        {
            if (_context.DynamicContents is null)
            {
                throw new NullReferenceException($"{nameof(_context.DynamicContents)} is null");
            }

            return await _context.DynamicContents
                .Where(dc => dc.ShowInTopPosition && dc.IsVisible)
                .Include(dc => dc.DynamicContentCategories)
                .OrderBy(dc => dc.Id)
                .Take(_visibleTopContent)
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

            int result = (int)Math.Ceiling(total / _visibleContentByPage);

            return result;
        }
    }
}
