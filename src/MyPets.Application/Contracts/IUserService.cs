using MyPets.Application.Requests;

namespace MyPets.Application.Contracts;

public interface IUserService
{
    Task<Guid> RegisterAsync(RegisterUserRequest request);
    Task<string> LoginAsync(LoginUserRequest request);
}