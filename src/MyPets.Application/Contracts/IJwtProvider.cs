namespace MyPets.Application.Contracts;

public interface IJwtProvider
{
    string GenerateAccessJwtToken(string userId, string username);
}