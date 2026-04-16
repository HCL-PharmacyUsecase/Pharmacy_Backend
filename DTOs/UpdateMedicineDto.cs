using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.DTOs;

public class UpdateMedicineDto
{
    [MaxLength(200)]
    public string? Name { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue)]
    public int? Stock { get; set; }

    public int? CategoryId { get; set; }

    [MaxLength(100)]
    public string? Dosage { get; set; }

    [MaxLength(100)]
    public string? Packaging { get; set; }

    public bool? RequiresPrescription { get; set; }
}