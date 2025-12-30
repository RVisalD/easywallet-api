namespace easywallet_api.DTOs.Request.UserResponseDto;

using System.ComponentModel.DataAnnotations;

public class UserResponseDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public UserResponseDto(string phoneNumber, string firstName, string lastName, string token)
    {
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
        Token = token;
    }
}