using System.ComponentModel.DataAnnotations;

namespace MyPets.Application.Requests;

public record LoginUserRequest([Required] string Email, [Required] string Password);