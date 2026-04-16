using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Data;
using Pharmacy.API.Models;

namespace Pharmacy.API.Repositories
{
    public class HealthPackageRepository : IHealthPackageRepository
    {
        private readonly AppDbContext _context;
        public HealthPackageRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<HealthPackage>> GetAllAsync() =>
            await _context.HealthPackages.Include(hp => hp.Medicines).ToListAsync();

        public async Task<HealthPackage?> GetByIdAsync(int id) =>
            await _context.HealthPackages.Include(hp => hp.Medicines).FirstOrDefaultAsync(hp => hp.Id == id);
    }

    public interface IHealthPackageRepository
    {
        Task<IEnumerable<HealthPackage>> GetAllAsync();
        Task<HealthPackage?> GetByIdAsync(int id);
    }
}