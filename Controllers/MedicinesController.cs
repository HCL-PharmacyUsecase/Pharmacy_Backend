using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.DTOs;

namespace Pharmacy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicinesController : ControllerBase
{
    // Assume IMedicineService is injected by the other developer
    // private readonly IMedicineService _medicineService;

    // public MedicinesController(IMedicineService medicineService)
    // {
    //     _medicineService = medicineService;
    // }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] int? categoryId = null)
    {
        // var result = await _medicineService.GetAllAsync(page, pageSize, categoryId);
        // return Ok(result);

        return Ok(new ApiResponseDto<List<MedicineDto>>
        {
            Success = true,
            Message = "Medicines retrieved",
            Data = new List<MedicineDto>()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // var result = await _medicineService.GetByIdAsync(id);
        // return Ok(result);

        return Ok(new ApiResponseDto<MedicineDto>
        {
            Success = true,
            Message = "Medicine retrieved",
            Data = new MedicineDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMedicineDto dto)
    {
        // var result = await _medicineService.CreateAsync(dto);
        // return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        return Ok(new ApiResponseDto<MedicineDto>
        {
            Success = true,
            Message = "Medicine created",
            Data = new MedicineDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMedicineDto dto)
    {
        // var result = await _medicineService.UpdateAsync(id, dto);
        // return Ok(result);

        return Ok(new ApiResponseDto<MedicineDto>
        {
            Success = true,
            Message = "Medicine updated",
            Data = new MedicineDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // await _medicineService.DeleteAsync(id);
        // return NoContent();

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Medicine deleted",
            Data = null
        });
    }
}