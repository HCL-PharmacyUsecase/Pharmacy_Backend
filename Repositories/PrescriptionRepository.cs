using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Data;
using Pharmacy.API.Models;

namespace Pharmacy.API.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly AppDbContext _context;
        public PrescriptionRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Prescription>> GetByUserIdAsync(int userId) =>
            await _context.Prescriptions.Where(p => p.UserId == userId).ToListAsync();

        public async Task AddAsync(Prescription prescription)
        {
            await _context.Prescriptions.AddAsync(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<Prescription?> GetByIdAsync(int id) => await _context.Prescriptions.FindAsync(id);

        public async Task UpdateAsync(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
        }
    }

    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetByUserIdAsync(int userId);
        Task AddAsync(Prescription prescription);
        Task<Prescription?> GetByIdAsync(int id);
        Task UpdateAsync(Prescription prescription);
    }
}