using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Data;
using Pharmacy.API.Models;

namespace Pharmacy.API.Repositories
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly AppDbContext _context;
        public MedicineRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Medicine>> GetAllAsync() =>
            await _context.Medicines.Include(m => m.Category).ToListAsync();

        public async Task<IEnumerable<Medicine>> GetByCategoryAsync(int categoryId) =>
            await _context.Medicines.Where(m => m.CategoryId == categoryId).ToListAsync();

        public async Task<Medicine?> GetByIdAsync(int id) =>
            await _context.Medicines.FindAsync(id);

        public async Task AddAsync(Medicine medicine)
        {
            await _context.Medicines.AddAsync(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
            await _context.SaveChangesAsync();
        }
    }

    public interface IMedicineRepository
    {
        Task<IEnumerable<Medicine>> GetAllAsync();
        Task<IEnumerable<Medicine>> GetByCategoryAsync(int categoryId);
        Task<Medicine?> GetByIdAsync(int id);
        Task AddAsync(Medicine medicine);
        Task UpdateAsync(Medicine medicine);
    }
}