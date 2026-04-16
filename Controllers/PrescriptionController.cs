using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.DTOs;

namespace Pharmacy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PrescriptionController : ControllerBase
{
    // Assume IPrescriptionService is injected by the other developer
    // private readonly IPrescriptionService _prescriptionService;

    // public PrescriptionController(IPrescriptionService prescriptionService)
    // {
    //     _prescriptionService = prescriptionService;
    // }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadPrescription([FromForm] UploadPrescriptionDto dto)
    {
        // var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
        // var result = await _prescriptionService.UploadPrescriptionAsync(userId, dto);
        // return Ok(result);

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Prescription uploaded successfully",
            Data = "Prescription ID"
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("{id}/validate")]
    public async Task<IActionResult> ValidatePrescription(int id, [FromBody] bool isApproved)
    {
        // var result = await _prescriptionService.ValidatePrescriptionAsync(id, isApproved);
        // return Ok(result);

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Prescription validated",
            Data = null
        });
    }

    [HttpGet("my-prescriptions")]
    public async Task<IActionResult> GetMyPrescriptions()
    {
        // var userId = int.Parse(User.FindFirst("UserId")?.Value ?? "0");
        // var result = await _prescriptionService.GetUserPrescriptionsAsync(userId);
        // return Ok(result);

        return Ok(new ApiResponseDto<List<object>>
        {
            Success = true,
            Message = "Prescriptions retrieved",
            Data = new List<object>()
        });
    }
}