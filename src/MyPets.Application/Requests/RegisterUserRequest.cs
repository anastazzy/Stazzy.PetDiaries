namespace MyPets.Application.Requests;

public record RegisterUserRequest(string Name, string Email, string Password)
{
}