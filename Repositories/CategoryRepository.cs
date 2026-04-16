using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Data;
using Pharmacy.API.Models;

namespace Pharmacy.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
        public async Task<Category?> GetByIdAsync(int id) => await _context.Categories.FindAsync(id);

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
    }

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
    }
}