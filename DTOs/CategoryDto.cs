using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.DTOs;

public class CategoryDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
}