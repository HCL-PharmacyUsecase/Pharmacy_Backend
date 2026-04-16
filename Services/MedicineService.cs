using Pharmacy.API.DTOs;
using Pharmacy.API.Helpers;
using Pharmacy.API.Models;
using Pharmacy.API.Repositories;

namespace Pharmacy.API.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository) => _medicineRepository = medicineRepository;

        public async Task<IEnumerable<Medicine>> GetAllMedicinesAsync() => await _medicineRepository.GetAllAsync();

        public async Task<IEnumerable<Medicine>> GetMedicinesByCategoryAsync(int categoryId) =>
            await _medicineRepository.GetByCategoryAsync(categoryId);

        public async Task<ApiResponseDto> CreateMedicineAsync(Medicine medicine)
        {
            await _medicineRepository.AddAsync(medicine);
            return new ApiResponseDto(true, "Medicine created successfully", medicine);
        }
    }

    public interface IMedicineService
    {
        Task<IEnumerable<Medicine>> GetAllMedicinesAsync();
        Task<IEnumerable<Medicine>> GetMedicinesByCategoryAsync(int categoryId);
        Task<ApiResponseDto> CreateMedicineAsync(Medicine medicine);
    }
}