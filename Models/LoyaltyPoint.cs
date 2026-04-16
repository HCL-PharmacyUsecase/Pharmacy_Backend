using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.Models;

public class LoyaltyPoint
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int Points { get; set; }

    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public User User { get; set; } = null!;
}