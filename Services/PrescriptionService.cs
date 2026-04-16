using Pharmacy.API.DTOs;
using Pharmacy.API.Helpers;
using Pharmacy.API.Models;
using Pharmacy.API.Repositories;

namespace Pharmacy.API.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IWebHostEnvironment _env;

        public PrescriptionService(IPrescriptionRepository prescriptionRepo, IWebHostEnvironment env)
        {
            _prescriptionRepository = prescriptionRepo;
            _env = env;
        }

        public async Task<ApiResponseDto> UploadPrescriptionAsync(int userId, IFormFile file)
        {
            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            var filePath = await FileHelper.SaveFileAsync(file, uploads);

            var prescription = new Prescription
            {
                UserId = userId,
                FilePath = filePath,
                Status = EnumHelper.PrescriptionPending,
                Date = DateTime.UtcNow
            };

            await _prescriptionRepository.AddAsync(prescription);
            return new ApiResponseDto(true, "Prescription uploaded successfully", prescription);
        }

        public async Task<IEnumerable<Prescription>> GetUserPrescriptionsAsync(int userId)
        {
            return await _prescriptionRepository.GetByUserIdAsync(userId);
        }
    }

    public interface IPrescriptionService
    {
        Task<ApiResponseDto> UploadPrescriptionAsync(int userId, IFormFile file);
        Task<IEnumerable<Prescription>> GetUserPrescriptionsAsync(int userId);
    }
}