using easywallet_api.Data;
using easywallet_api.Request.DTOs;
using easywallet_api.Helpers;
using easywallet_api.Models;
using easywallet_api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using easywallet_api.DTOs.Request.UserResponseDto;

namespace easywallet_api.Controllers;

[ApiController]
[Route("api/auth")]

public class AuthenticationController: ControllerBase
{

    private readonly UserContext _context;

    public AuthenticationController(UserContext context)
    {
        _context = context;
    }

   [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber);

        if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
        {
            return Unauthorized(BaseResponse<object>.FailResponse("Invalid phone number or password."));
        }
        var token = JWT.GenerateToken(user.Id);
        var response = new UserResponseDto(user.PhoneNumber, user.FirstName, user.LastName, token);
        return Ok(BaseResponse<UserResponseDto>.SuccessResponse(response, "Login successful."));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {

        if (await _context.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber))
        {
            return BadRequest("User with this phone number already exists.");
        }

        var passwordHash = PasswordHasher.HashPassword(dto.Password);

        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash = passwordHash
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User registered successfully." });
    }
}