using MyPets.Application.Contracts;
using MyPets.Application.Requests;
using MyPets.DataAccess;
using MyPets.Domain.Models;

namespace MyPets.Application.Services;

public class UserService : IUserService
{
    private readonly MyPetsDbContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(MyPetsDbContext dbContext, IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }
    public async Task<Guid> CreateAsync(RegisterUserRequest request)
    {
        var generateResult = _passwordHasher.GetHash(request.Password);
        var user = new User(request.Name, request.Email, generateResult.PasswordHash, generateResult.PasswordSalt);

        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }

    public Task<string> LoginAsync(LoginUserRequest request)
    {
        throw new NotImplementedException();
    }
}