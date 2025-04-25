using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MyPets.Application.Contracts;
using MyPets.Application.Dtos;

namespace MyPets.Application.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltLength = 64;
    private const int IterationCount = 1000;

    /// <summary>
    ///     Требуемая длина (в байтах) производного ключа.
    ///     https://learn.microsoft.com/ru-ru/dotnet/api/microsoft.aspnetcore.cryptography.keyderivation.keyderivation.pbkdf2?view=aspnetcore-9.0
    /// </summary>
    private const int KeyLenght = 256 / 8;

    public GenerateHashResult GetHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltLength);

        var hashed = GenerateHash(password, salt);

        return new GenerateHashResult(hashed, Convert.ToBase64String(salt));
    }

    public bool Verify(string password, string hash, string salt)
    {
        var enteredHash = GenerateHash(password, Convert.FromBase64String(salt));
        return enteredHash == hash;
    }

    private string GenerateHash(string password, byte[] salt) =>
        Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password,
            salt,
            KeyDerivationPrf.HMACSHA256,
            IterationCount,
            KeyLenght));
}