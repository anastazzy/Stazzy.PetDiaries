using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyPets.Application.Dtos;

namespace MyPets.API.Extensions;

public static class ApiExtensions
{
    public static void AddApiAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()?.SecretKey ?? string.Empty;
        var cookiesName = configuration.GetSection(nameof(CookiesOptions)).Get<CookiesOptions>()?.AuthName ?? string.Empty;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions)),
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies.TryGetValue(cookiesName, out var value) ? value : string.Empty;
                        return Task.CompletedTask;
                    }
                };
            });
        services.AddAuthorization();
    }
}