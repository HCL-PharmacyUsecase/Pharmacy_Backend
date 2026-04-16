using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Data;
using Pharmacy.API.Models;

namespace Pharmacy.API.Repositories
{
    public class LoyaltyRepository : ILoyaltyRepository
    {
        private readonly AppDbContext _context;
        public LoyaltyRepository(AppDbContext context) => _context = context;

        public async Task<int> GetUserPointsAsync(int userId)
        {
            var points = await _context.LoyaltyPoints.FirstOrDefaultAsync(lp => lp.UserId == userId);
            return points?.Points ?? 0;
        }

        public async Task UpdatePointsAsync(int userId, int pointsToAdd)
        {
            var userPoints = await _context.LoyaltyPoints.FirstOrDefaultAsync(lp => lp.UserId == userId);
            if (userPoints == null)
            {
                userPoints = new LoyaltyPoint { UserId = userId, Points = pointsToAdd };
                await _context.LoyaltyPoints.AddAsync(userPoints);
            }
            else
            {
                userPoints.Points += pointsToAdd;
                _context.LoyaltyPoints.Update(userPoints);
            }
            await _context.SaveChangesAsync();
        }
    }

    public interface ILoyaltyRepository
    {
        Task<int> GetUserPointsAsync(int userId);
        Task UpdatePointsAsync(int userId, int pointsToAdd);
    }
}