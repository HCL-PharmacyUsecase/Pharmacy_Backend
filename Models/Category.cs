using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}