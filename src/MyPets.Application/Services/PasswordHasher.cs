using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MyPets.Application.Contracts;
using MyPets.Application.Dtos;

namespace MyPets.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    const int SaltLength = 64;
    const int IterationCount = 1000;
    /// <summary>
    /// Требуемая длина (в байтах) производного ключа.
    /// https://learn.microsoft.com/ru-ru/dotnet/api/microsoft.aspnetcore.cryptography.keyderivation.keyderivation.pbkdf2?view=aspnetcore-9.0
    /// </summary>
    private const int KeyLenght = 256 / 8; 
    
    public GenerateHashResult GetHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltLength);
        
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: IterationCount,
            numBytesRequested: KeyLenght));

        return new GenerateHashResult(Convert.ToBase64String(salt), hashed);
    }

    public bool Verify(string password, string hash)
    {
        throw new NotImplementedException();
    }
}