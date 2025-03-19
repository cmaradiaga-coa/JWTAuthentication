using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models.Api;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly JwtService _jwtService;

    //? Esta es la forma corta de hacer inyección de dependencias:
    public AccountController(JwtService jwtService) =>
         _jwtService = jwtService;


    //? Esta sería la forma común.
    // public AccountController(JwtService jwtService)
    // {
    //     _jwtService = jwtService;
    // }

    //? POST: api/Account/Login 
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel request)
    {
        var result = await _jwtService.Authenticate(request);
        if(result is null)
            return Unauthorized();

        return result;
    }
}
