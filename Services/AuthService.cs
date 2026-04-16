using Pharmacy.API.DTOs;
using Pharmacy.API.Helpers;
using Pharmacy.API.Models;
using Pharmacy.API.Repositories;

namespace Pharmacy.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ApiResponseDto> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null) return new ApiResponseDto(false, "Email already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = PasswordHasher.HashPassword(dto.Password),
                Role = EnumHelper.RoleCustomer
            };

            await _userRepository.AddAsync(user);
            return new ApiResponseDto(true, "Registration successful");
        }

        public async Task<ApiResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return new ApiResponseDto(false, "Invalid email or password");

            var token = JwtHelper.GenerateToken(user, _configuration);
            return new ApiResponseDto(true, "Login successful", new { Token = token, Role = user.Role });
        }
    }

    public interface IAuthService
    {
        Task<ApiResponseDto> RegisterAsync(RegisterDto dto);
        Task<ApiResponseDto> LoginAsync(LoginDto dto);
    }
}