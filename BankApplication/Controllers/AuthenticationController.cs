using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Application.Authentication;
using BankApplication.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers;




  [Route("auth")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.UserId,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {

        var authResult = _authenticationService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.User.UserId,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.token);
        return Ok(response);
    }
    
  }
