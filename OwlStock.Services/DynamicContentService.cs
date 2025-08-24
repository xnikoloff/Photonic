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
        private const int _visibleTopContent = 4;

        private readonly OwlStockDbContext _context;
        private readonly ILogger<DynamicContentService> _logger;

        public DynamicContentService(OwlStockDbContext context, ILogger<DynamicContentService> logger)
        {
            _context = context ?? new();
            _logger = logger;

        }

        public async Task<bool> Create(CreateDynamicContentDTO dto)
        {
            if (dto == null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Create)}, ${nameof(dto)} was null");
                return false;

            }

            if (dto.DynamicContent == null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Create)}, {nameof(dto.DynamicContent)} was null");
                return false;
            }

            if (dto.DynamicContent.Content == null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Create)}, {nameof(dto.DynamicContent.Content)} was null");
                return false;
            }

            if (dto.Image == null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Create)}, {nameof(dto.Image)} was null");
                return false;
            }

            if (dto.WebRootPath == null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Create)}, {nameof(dto.WebRootPath)} was null");
                return false;
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

            try
            {
                dto!.DynamicContent.ImageName = dto?.Image?.FileName;
                dto!.DynamicContent.CreatedOn = DateTime.Now;

                await _context.AddAsync(dto!.DynamicContent);
                int result = await _context.SaveChangesAsync();

                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Delete)}, {nameof(_context.DynamicContents)} is null");
                return false;
            }

            try
            {
                DynamicContent? dynamicContent = await _context.DynamicContents.FindAsync(id);

                if(dynamicContent == null)
                {
                    _logger.LogError($"DynamicContent with Id {id} was not found, {DateTime.UtcNow}, {nameof(Delete)}");
                    return false;
                }

                dynamicContent.IsVisible = false;
                dynamicContent.DeletedOn = DateTime.Now;
                
                await _context.SaveChangesAsync();
                return true;
            }

            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }

        public async Task<bool> Recover(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(Recover)}, {nameof(_context.DynamicContents)} is null");
                return false;
            }
            try
            {
                DynamicContent? dynamicContent = await _context.DynamicContents.FindAsync(id);
                if (dynamicContent == null)
                {
                    _logger.LogError($"DynamicContent with Id {id} was not found, {DateTime.UtcNow}, {nameof(Recover)}");
                    return false;
                }
                dynamicContent.IsVisible = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return false;
            }
        }

        public async Task<DynamicContent> GetById(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetById)}, {nameof(_context.DynamicContents)} was null");
                return new();
            }

            try
            {
                return await _context.DynamicContents
                .Include(dc => dc.DynamicContentCategories)
                .ThenInclude(dcc => dcc!.DynamicContents)
                .Where(dc => dc.Id == id)
                .FirstOrDefaultAsync() ?? new();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        public async Task<AllDynamicContentsDTO> GetAll()
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAll)}, {nameof(_context.DynamicContents)} was null");
                return new();
            }

            if (_context.DynamicContentCategories is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAll)}, {nameof(_context.DynamicContentCategories)} was null");
                return new();
            }

            try
            {
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

            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }            
        }

        public async Task<AllDynamicContentsDTO> GetAllByCategory(Guid id)
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByCategory)}, {nameof(_context.DynamicContents)} was null");
                return new();
            }

            if (_context.DynamicContentCategories is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByCategory)}, {nameof(_context.DynamicContentCategories)} was null");
                return new();
            }

            if (id == Guid.Empty)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByCategory)}, {nameof(id)} was null or empty");
                return new();
            }

            try
            {
                List<DynamicContent>? dynamicContents = await _context.DynamicContents
                   .Include(dc => dc.CreatedBy)
                   .Include(dc => dc.DynamicContentCategories)
                   .Where(dc => dc.DynamicContentCategories!.Id == id)
                   .ToListAsync();

                List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

                return new AllDynamicContentsDTO()
                {
                    DynamicContents = dynamicContents,
                    DynamicContentCategories = dynamicContentCategories
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        public async Task<AllDynamicContentsDTO> GetAllDeleted()
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByCategory)}, {nameof(_context.DynamicContents)} was null");
                return new();
            }

            if (_context.DynamicContentCategories is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByCategory)}, {nameof(_context.DynamicContentCategories)} was null");
                return new();
            }

            try
            {
                List<DynamicContent>? dynamicContents = await _context.DynamicContents
                   .Include(dc => dc.CreatedBy)
                   .Include(dc => dc.DynamicContentCategories)
                   .Where(dc => dc.IsVisible == false)
                   .ToListAsync();

                List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

                return new AllDynamicContentsDTO()
                {
                    DynamicContents = dynamicContents,
                    DynamicContentCategories = dynamicContentCategories
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        public async Task<AllDynamicContentsDTO> GetAllByPage(int pageNumber)
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByPage)}, {nameof(_context.DynamicContents)} was null");
                return new();
            }

            if (_context.DynamicContentCategories is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByPage)}, {nameof(_context.DynamicContentCategories)} was null");
                return new();
            }

            if (pageNumber <= 0) 
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByPage)}, {nameof(pageNumber)} was 0 or less that 0");
                return new();
            }

            try
            {
                List<DynamicContent> dynamicContents = await _context.DynamicContents
                .Where(dc => dc.IsVisible)
                .Include(dc => dc.CreatedBy)
                .Skip((pageNumber * _visibleContentByPage) - _visibleContentByPage)
                .Take(_visibleContentByPage)
                .ToListAsync();

                List<DynamicContentCategory>? dynamicContentCategories = await _context.DynamicContentCategories.ToListAsync();

                int pageCount = await CalculatePagesNumber();

                if(pageCount == -1)
                {
                    _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByPage)}, {nameof(CalculatePagesNumber)} returned -1");
                    return new();
                }

                return new AllDynamicContentsDTO()
                {
                    DynamicContents = dynamicContents,
                    DynamicContentCategories = dynamicContentCategories,
                    PagesCount = pageCount
                };
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new();
            }
        }

        public async Task<IEnumerable<DynamicContent>> GetTopContent()
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllByPage)}, {nameof(_context.DynamicContents)} was null");
                return new List<DynamicContent>();
            }

            try
            {
                return await _context.DynamicContents
                    .Where(dc => dc.ShowInTopPosition && dc.IsVisible)
                    .Include(dc => dc.DynamicContentCategories)
                    .OrderBy(dc => dc.Id)
                    .Take(_visibleTopContent)
                    .ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new List<DynamicContent>();
            }
        }

        public async Task<IEnumerable<DynamicContentCategory>> GetAllDynamicContentCategories()
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllDynamicContentCategories)}, {nameof(_context.DynamicContents)} was null");
                return new List<DynamicContentCategory>();
            }

            if (_context.DynamicContentCategories is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(GetAllDynamicContentCategories)}, {nameof(_context.DynamicContentCategories)} was null");
                return new List<DynamicContentCategory>();
            }

            try
            {
                return await _context.DynamicContentCategories.ToListAsync();
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return new List<DynamicContentCategory>();
            }
        }

        /// <summary>
        /// Creates new DynamicContentCategory if the name of the category is not null
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>If created, Id of the created DynamucContentCategory, else empty GUID</returns>
        private async Task<CreateDynamicContentCategoryDTO> CreateDynamicContentCategory(CreateDynamicContentCategoryDTO dto)
        {
            if (_context.DynamicContentCategories == null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(CreateDynamicContentCategory)}, {nameof(_context.DynamicContentCategories)} was null");
                dto.IsSuccessful = false;
                return dto;
            }

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

        private async Task<int> CalculatePagesNumber()
        {
            if (_context.DynamicContents is null)
            {
                _logger.LogError(null, $"An error occurred at {DateTime.UtcNow}, {nameof(CalculatePagesNumber)}, {nameof(_context.DynamicContents)} was null");
                return -1;
            }

            try
            {
                double total = await _context.DynamicContents.CountAsync();

                if (total == 0)
                {
                    return 0;
                }

                int result = (int)Math.Ceiling(total / _visibleContentByPage);

                return result;
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred at {Time}", DateTime.UtcNow);
                return -1;
            }
        }
    }
}
