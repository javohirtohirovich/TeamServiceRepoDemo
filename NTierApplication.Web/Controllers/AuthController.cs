using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NTierApplication.DataAccess.Models;
using NTierApplication.Service;
using NTierApplication.Service.ViewModels;

namespace NTierApplication.Web.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private IUserService _service;

    public AuthController(IUserService userService) 
    {
        _service = userService;
    }
    
    [HttpPost("register")]
    public IActionResult Register(UserRegisterModel userViewModel)
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
