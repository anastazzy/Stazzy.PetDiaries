using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyPets.Application.Contracts;
using MyPets.Application.Dtos;

namespace MyPets.Application.Services;

public class JwtProvider(IOptions<JwtOptions> settings) : IJwtProvider
{
    private const string SigningAlgorithm = SecurityAlgorithms.HmacSha256;
    private readonly JwtOptions _options = settings.Value;

    public string GenerateAccessJwtToken(string userId, string username)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretKey));
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Sid, userId),
        };

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(_options.HourLifeTime),
            signingCredentials: new SigningCredentials(securityKey, SigningAlgorithm)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}