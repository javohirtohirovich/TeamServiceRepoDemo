using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierApplication.Service;
using NTierApplication.Service.ViewModels;

namespace NTierApplication.Web.Controllers;

[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _service;

    public UserController(IUserService userService) 
    {
        _service = userService;
    }
    [HttpPost("register")]
    public IActionResult Register(UserViewModel userViewModel)
    {
        var result=_service.Register(userViewModel);
        return Ok(new { result.Result, result.Token });
    }
    [HttpPost("login")]
    public IActionResult Login(UserLoginView userLoginViewModel)
    {
        var result = _service.Login(userLoginViewModel);
        return Ok(new {result.Result, result.Token});
    }
}
