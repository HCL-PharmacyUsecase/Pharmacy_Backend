using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.DTOs;

namespace Pharmacy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    // Assume ICategoryService is injected by the other developer
    // private readonly ICategoryService _categoryService;

    // public CategoriesController(ICategoryService categoryService)
    // {
    //     _categoryService = categoryService;
    // }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // var result = await _categoryService.GetAllAsync();
        // return Ok(result);

        return Ok(new ApiResponseDto<List<CategoryDto>>
        {
            Success = true,
            Message = "Categories retrieved",
            Data = new List<CategoryDto>()
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // var result = await _categoryService.GetByIdAsync(id);
        // return Ok(result);

        return Ok(new ApiResponseDto<CategoryDto>
        {
            Success = true,
            Message = "Category retrieved",
            Data = new CategoryDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CategoryDto dto)
    {
        // var result = await _categoryService.CreateAsync(dto);
        // return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);

        return Ok(new ApiResponseDto<CategoryDto>
        {
            Success = true,
            Message = "Category created",
            Data = new CategoryDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CategoryDto dto)
    {
        // var result = await _categoryService.UpdateAsync(id, dto);
        // return Ok(result);

        return Ok(new ApiResponseDto<CategoryDto>
        {
            Success = true,
            Message = "Category updated",
            Data = new CategoryDto()
        });
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // await _categoryService.DeleteAsync(id);
        // return NoContent();

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Category deleted",
            Data = null
        });
    }
}