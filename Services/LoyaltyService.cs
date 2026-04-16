using Pharmacy.API.Repositories;

namespace Pharmacy.API.Services
{
    public class LoyaltyService : ILoyaltyService
    {
        private readonly ILoyaltyRepository _loyaltyRepository;

        // Logic: 1 Point for every $10 spent
        private const decimal PointsPerCurrency = 10m;

        public LoyaltyService(ILoyaltyRepository loyaltyRepo)
        {
            _loyaltyRepository = loyaltyRepo;
        }

        public async Task AddPointsAsync(int userId, decimal totalAmount)
        {
            int pointsToAdd = (int)(totalAmount / PointsPerCurrency);
            if (pointsToAdd > 0)
            {
                await _loyaltyRepository.UpdatePointsAsync(userId, pointsToAdd);
            }
        }

        public async Task<int> GetUserPointsAsync(int userId)
        {
            return await _loyaltyRepository.GetUserPointsAsync(userId);
        }
    }

    public interface ILoyaltyService
    {
        Task AddPointsAsync(int userId, decimal totalAmount);
        Task<int> GetUserPointsAsync(int userId);
    }
}