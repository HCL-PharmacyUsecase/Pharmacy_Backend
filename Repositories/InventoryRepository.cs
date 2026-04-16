using Pharmacy.API.Data;
using Pharmacy.API.Models;

namespace Pharmacy.API.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;
        public InventoryRepository(AppDbContext context) => _context = context;

        public async Task LogChangeAsync(InventoryLog log)
        {
            await _context.InventoryLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }

    public interface IInventoryRepository
    {
        Task LogChangeAsync(InventoryLog log);
    }
}