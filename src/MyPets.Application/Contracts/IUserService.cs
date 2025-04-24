using MyPets.Application.Requests;

namespace MyPets.Application.Contracts;

public interface IUserService
{
    Task<Guid> CreateAsync(RegisterUserRequest request);
    Task<string> LoginAsync(LoginUserRequest request);
}