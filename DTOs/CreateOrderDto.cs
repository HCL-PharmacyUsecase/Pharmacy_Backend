using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.DTOs;

public class CreateOrderDto
{
    [Required]
    public List<OrderItemDto> Items { get; set; } = new();
}