using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.Models;

public class InventoryLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int MedicineId { get; set; }

    [Required]
    public int Change { get; set; } // Positive for addition, negative for deduction

    public DateTime Date { get; set; } = DateTime.UtcNow;

    [MaxLength(200)]
    public string? Reason { get; set; }

    // Navigation Properties
    public Medicine Medicine { get; set; } = null!;
}