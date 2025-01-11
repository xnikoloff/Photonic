using Microsoft.EntityFrameworkCore;
using OwlStock.Domain.Entities;
using OwlStock.Infrastructure;

namespace OwlStock.Services.Interfaces
{
    public class TestimonyService : ITestimonyService
    {
        private readonly OwlStockDbContext _context;

        public TestimonyService(OwlStockDbContext context)
        {
            _context = context;
        }

        public async Task<Testimony> Create(Testimony testimony)
        {
            if(_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            testimony.CreatedOn = DateTime.Now;
            testimony.IsApproved = false;
            testimony.IsHidden = false;
            
            await _context.AddAsync(testimony);
            await _context.SaveChangesAsync();

            return testimony;
        }

        public async Task<Testimony> Approve(Guid id)
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            Testimony? testimony = await _context.Testimonies
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (testimony == null)
            {
                throw new NullReferenceException($"{nameof(testimony)} with Id {id} cannot be found");
            }

            testimony.IsApproved = true;
            testimony.ApprovedOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return testimony;
        }
        
        public async Task<Testimony> Hide(Guid id)
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            Testimony? testimony = await _context.Testimonies
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (testimony == null)
            {
                throw new NullReferenceException($"{nameof(testimony)} with Id {id} cannot be found");
            }

            testimony.IsHidden = true;
            testimony.HiddenOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return testimony;
        }

        public async Task<Testimony> Unhide(Guid id)
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            Testimony? testimony = await _context.Testimonies
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            if (testimony == null)
            {
                throw new NullReferenceException($"{nameof(testimony)} with Id {id} cannot be found");
            }

            testimony.IsHidden = false;
            testimony.UnhiddenOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return testimony;
        }

        public async Task<IEnumerable<Testimony>> GetLastFour()
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            return await _context.Testimonies
                .Where(t => t.IsHidden == false && t.IsApproved)
                .OrderByDescending(t => t.CreatedOn)
                .Take(4)
                .ToListAsync();
        }

        public async Task<IEnumerable<Testimony>> GetApproved()
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            return await _context.Testimonies
                .Where(t => t.IsHidden == false && t.IsApproved)
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync();
        }

        public async Task<IEnumerable<Testimony>> GetHidden()
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            return await _context.Testimonies
                .Where(t => t.IsHidden)
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync();
        }

        public async Task<IEnumerable<Testimony>> GetNew()
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            return await _context.Testimonies
                .Where(t => t.IsHidden == false && t.IsApproved == false)
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync();
        }

        public async Task<IEnumerable<Testimony>> GetUnhidden()
        {
            if (_context.Testimonies is null)
            {
                throw new NullReferenceException($"{nameof(_context.Testimonies)} is null");
            }

            return await _context.Testimonies
                .Where(t => t.IsHidden == false && t.HiddenOn != null)
                .OrderByDescending(t => t.CreatedOn)
                .ToListAsync();
        }
    }
}
