using System.ComponentModel.DataAnnotations;

namespace easywallet_api.Request.DTOs;

public class LoginDto
{
    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string Password { get; set; } = string.Empty;
}