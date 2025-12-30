namespace easywallet_api.DTOs.Request.UserResponseDto;

using System.ComponentModel.DataAnnotations;

public class UserResponseDto
{
    public string UID { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public UserResponseDto(string uid, string phoneNumber, string firstName, string lastName, string token)
    {
        UID = uid;
        PhoneNumber = phoneNumber;
        FirstName = firstName;
        LastName = lastName;
        Token = token;
    }
}