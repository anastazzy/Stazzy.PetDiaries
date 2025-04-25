using Microsoft.EntityFrameworkCore;
using MyPets.Application.Contracts;
using MyPets.Application.Requests;
using MyPets.DataAccess;
using MyPets.Domain.Models;

namespace MyPets.Application.Services;

public class UserService : IUserService
{
    private readonly MyPetsDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public UserService(MyPetsDbContext dbContext, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }
    public async Task<Guid> RegisterAsync(RegisterUserRequest request)
    {
        var generateResult = _passwordHasher.GetHash(request.Password);
        var user = new User(request.Name, request.Email, generateResult.PasswordHash, generateResult.PasswordSalt);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }

    public async Task<string> LoginAsync(LoginUserRequest request)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == request.Email);

        if (user is null)
            return string.Empty;

        var isPasswordMatch = _passwordHasher.Verify(request.Password, user.PasswordHash, user.Salt);
        if (!isPasswordMatch)
            return string.Empty;

        var token = _jwtProvider.GenerateAccessJwtToken(user.Id.ToString(), user.Name);
        return token;
    }
}