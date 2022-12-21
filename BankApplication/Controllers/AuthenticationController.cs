using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Application.Authentication;
using BankApplication.Application.Authentication.Commands;
using BankApplication.Application.Authentication.Queries;
using BankApplication.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers;




  [Route("auth")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationCommandService _authenticationCommandService;
    private readonly IAuthenticationQueryService _authenticationQueryService;


    public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
    {
        _authenticationQueryService = authenticationQueryService;
        _authenticationCommandService = authenticationCommandService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationCommandService.Register(
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

        var authResult = _authenticationQueryService.Login(
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
