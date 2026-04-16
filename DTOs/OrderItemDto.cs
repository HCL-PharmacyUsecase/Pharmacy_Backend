using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.DTOs;

public class OrderItemDto
{
    [Required]
    public int MedicineId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}