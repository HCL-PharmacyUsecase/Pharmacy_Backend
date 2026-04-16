using Pharmacy.API.Helpers;
using Pharmacy.API.Models;
using Pharmacy.API.Repositories;

namespace Pharmacy.API.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IMedicineRepository medRepo, IInventoryRepository invRepo)
        {
            _medicineRepository = medRepo;
            _inventoryRepository = invRepo;
        }

        public async Task UpdateStockAsync(int medicineId, int quantitySold, int userId)
        {
            var medicine = await _medicineRepository.GetByIdAsync(medicineId);
            if (medicine != null)
            {
                medicine.Stock -= quantitySold;
                await _medicineRepository.UpdateAsync(medicine);

                // Log the change
                await _inventoryRepository.LogChangeAsync(new InventoryLog
                {
                    MedicineId = medicineId,
                    Change = -quantitySold, // Negative because stock decreased
                    Date = DateTime.UtcNow
                });
            }
        }
    }

    public interface IInventoryService
    {
        Task UpdateStockAsync(int medicineId, int quantitySold, int userId);
    }
}