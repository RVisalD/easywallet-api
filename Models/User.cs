using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace easywallet_api.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string UID { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [Required]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [JsonIgnore]
    public string PasswordHash { get; set; } = string.Empty;
}
