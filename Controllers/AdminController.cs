using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.DTOs;

namespace Pharmacy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController : ControllerBase
{
    // Assume IAdminService is injected by the other developer
    // private readonly IAdminService _adminService;

    // public AdminController(IAdminService adminService)
    // {
    //     _adminService = adminService;
    // }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        // var result = await _adminService.GetDashboardDataAsync();
        // return Ok(result);
        
        return Ok(new ApiResponseDto<object>
        {
            Success = true,
            Message = "Dashboard data retrieved",
            Data = new
            {
                TotalOrders = 0,
                TotalRevenue = 0m,
                LowStockMedicines = 0,
                PendingPrescriptions = 0
            }
        });
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetAllOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        // var result = await _adminService.GetAllOrdersAsync(page, pageSize);
        // return Ok(result);
        
        return Ok(new ApiResponseDto<List<OrderResponseDto>>
        {
            Success = true,
            Message = "All orders retrieved",
            Data = new List<OrderResponseDto>()
        });
    }

    [HttpGet("inventory/low-stock")]
    public async Task<IActionResult> GetLowStockMedicines([FromQuery] int threshold = 10)
    {
        // var result = await _adminService.GetLowStockMedicinesAsync(threshold);
        // return Ok(result);
        
        return Ok(new ApiResponseDto<List<MedicineDto>>
        {
            Success = true,
            Message = "Low stock medicines retrieved",
            Data = new List<MedicineDto>()
        });
    }

    [HttpGet("prescriptions/pending")]
    public async Task<IActionResult> GetPendingPrescriptions()
    {
        // var result = await _adminService.GetPendingPrescriptionsAsync();
        // return Ok(result);
        
        return Ok(new ApiResponseDto<List<object>>
        {
            Success = true,
            Message = "Pending prescriptions retrieved",
            Data = new List<object>()
        });
    }
}