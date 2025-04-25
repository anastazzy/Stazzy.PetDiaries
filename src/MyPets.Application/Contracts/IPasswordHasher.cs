using MyPets.Application.Dtos;

namespace MyPets.Application.Contracts;

public interface IPasswordHasher
{
    GenerateHashResult GetHash(string password);
    bool Verify(string password, string hash, string salt);
}