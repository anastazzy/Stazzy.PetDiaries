using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPets.Application.Contracts;
using MyPets.Application.Dtos;
using MyPets.Application.Requests;

namespace MyPets.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly string _cookiesName;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _cookiesName = configuration.GetSection(nameof(CookiesOptions)).Get<CookiesOptions>()?.AuthName ?? string.Empty;
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

        HttpContext.Response.Cookies.Append(_cookiesName, token);
        return Ok(token);
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> LogoutAsync()
    {
        HttpContext.Response.Cookies.Delete(_cookiesName);
        return Ok();
    }

    [Authorize]
    [HttpGet("info")]
    public async Task<ActionResult> GetInfo()
    {
        return Ok(1);
    }
}