using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.API.DTOs;

namespace Pharmacy.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    // Assume IAuthService is injected by the other developer
    // private readonly IAuthService _authService;

    // public AuthController(IAuthService authService)
    // {
    //     _authService = authService;
    // }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        // var result = await _authService.RegisterAsync(dto);
        // return Ok(result);

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Registration successful",
            Data = "User registered"
        });
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        // var result = await _authService.LoginAsync(dto);
        // return Ok(result);

        return Ok(new ApiResponseDto<string>
        {
            Success = true,
            Message = "Login successful",
            Data = "JWT_TOKEN_HERE"
        });
    }
}