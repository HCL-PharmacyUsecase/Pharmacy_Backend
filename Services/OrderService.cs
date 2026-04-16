using Pharmacy.API.DTOs;
using Pharmacy.API.Helpers;
using Pharmacy.API.Models;
using Pharmacy.API.Repositories;

namespace Pharmacy.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMedicineRepository _medicineRepository;
        private readonly IInventoryService _inventoryService;
        private readonly ILoyaltyService _loyaltyService;
        private readonly IEmailService _emailService;

        public OrderService(IOrderRepository orderRepo, IMedicineRepository medRepo,
                             IInventoryService invService, ILoyaltyService loyaltyService, IEmailService emailService)
        {
            _orderRepository = orderRepo;
            _medicineRepository = medRepo;
            _inventoryService = invService;
            _loyaltyService = loyaltyService;
            _emailService = emailService;
        }

        public async Task<ApiResponseDto> PlaceOrderAsync(int userId, CreateOrderDto dto)
        {
            decimal totalAmount = 0;
            var orderItems = new List<OrderItem>();

            foreach (var item in dto.Items)
            {
                var medicine = await _medicineRepository.GetByIdAsync(item.MedicineId);
                if (medicine == null) return new ApiResponseDto(false, $"Medicine ID {item.MedicineId} not found");
                if (medicine.Stock < item.Quantity) return new ApiResponseDto(false, $"Insufficient stock for {medicine.Name}");

                totalAmount += medicine.Price * item.Quantity;
                orderItems.Add(new OrderItem
                {
                    MedicineId = item.MedicineId,
                    Quantity = item.Quantity,
                    Price = medicine.Price
                });
            }

            var order = new Order
            {
                UserId = userId,
                TotalAmount = totalAmount,
                Status = EnumHelper.OrderPending,
                CreatedAt = DateTime.UtcNow,
                OrderItems = orderItems
            };

            await _orderRepository.AddAsync(order);

            // Update Inventory
            foreach (var item in orderItems)
            {
                await _inventoryService.UpdateStockAsync(item.MedicineId, item.Quantity, userId);
            }

            // Update Loyalty Points
            await _loyaltyService.AddPointsAsync(userId, (int)totalAmount);

            // Send Email (Stretch)
            await _emailService.SendOrderConfirmationEmail("user@example.com", order.Id.ToString());

            return new ApiResponseDto(true, "Order placed successfully", new { OrderId = order.Id });
        }
    }

    public interface IOrderService
    {
        Task<ApiResponseDto> PlaceOrderAsync(int userId, CreateOrderDto dto);
    }
}