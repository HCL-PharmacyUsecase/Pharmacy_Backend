using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.DTOs;

namespace Pharmacy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthPackagesController : ControllerBase
{
    // Assume IHealthPackageService is injected by the other developer
    // private readonly IHealthPackageService _healthPackageService;

    // public HealthPackagesController(IHealthPackageService healthPackageService)
    // {
    //     _healthPackageService = healthPackageService;
    // }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // var result = await _healthPackageService.GetAllAsync();
        // return Ok(result);

        return Ok(new ApiResponseDto<List<HealthPackageDto>>
        {
            Success = true,
            Message = "Health packages retrieved",
            Data = new List<HealthPackageDto>()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // var result = await _healthPackageService.GetByIdAsync(id);
        // return Ok(result);

        return Ok(new ApiResponseDto<HealthPackageDto>
        {
            Success = true,
            Message = "Health package retrieved",
            Data = new HealthPackageDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] HealthPackageDto dto)
    {
        // var result = await _healthPackageService.CreateAsync(dto);
        // return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        return Ok(new ApiResponseDto<HealthPackageDto>
        {
            Success = true,
            Message = "Health package created",
            Data = new HealthPackageDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] HealthPackageDto dto)
    {
        // var result = await _healthPackageService.UpdateAsync(id, dto);
        // return Ok(result);

        return Ok(new ApiResponseDto<HealthPackageDto>
        {
            Success = true,
            Message = "Health package updated",
            Data = new HealthPackageDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // await _healthPackageService.DeleteAsync(id);
        // return NoContent();

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Health package deleted",
            Data = null
        });
    }
}