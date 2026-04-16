using System.ComponentModel.DataAnnotations;

namespace Pharmacy.API.DTOs;

public class UploadPrescriptionDto
{
    [Required]
    public IFormFile File { get; set; } = null!;
}