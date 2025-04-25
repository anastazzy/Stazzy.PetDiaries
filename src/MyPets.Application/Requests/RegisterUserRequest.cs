using System.ComponentModel.DataAnnotations;

namespace MyPets.Application.Requests;

public record RegisterUserRequest(
    [Required] string Name, 
    [Required] string Email, 
    [Required]string Password);