using Microsoft.AspNetCore.Mvc;
using MyPets.Application.Contracts;
using MyPets.Application.Requests;

namespace MyPets.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterUserRequest request)
    {
        var newUserId = await _userService.RegisterAsync(request);
        return Ok();
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> LoginAsync([FromBody] LoginUserRequest request)
    {
        var token = await _userService.LoginAsync(request);
        return Ok(token);
    }
}