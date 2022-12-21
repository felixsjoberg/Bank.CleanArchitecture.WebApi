using BankApplication.Application.Services.Commands.Register;
using BankApplication.Application.Services.Queries.Login;
using BankApplication.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers;




[Route("auth")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);
          var authResult = await _mediator.Send(command);

        var response = new AuthenticationResponse(
            authResult.user.UserId,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

        var response = new AuthenticationResponse(
            authResult.user.UserId,
            authResult.user.FirstName,
            authResult.user.LastName,
            authResult.user.Email,
            authResult.Token);
        return Ok(response);
    }
    
  }
