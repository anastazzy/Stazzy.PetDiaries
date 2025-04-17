using System.ComponentModel.DataAnnotations;

namespace MyPets.Domain.Models;

public class User
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
}