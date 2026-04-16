using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Role { get; set; } = "Customer"; // Admin, Customer

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    public LoyaltyPoint? LoyaltyPoint { get; set; }
}