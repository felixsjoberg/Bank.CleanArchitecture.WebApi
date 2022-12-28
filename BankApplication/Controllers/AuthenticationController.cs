using BankApplication.Application.Services.Commands.Register;
using BankApplication.Application.Services.Queries.Login;
using BankApplication.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Controllers;




[Route("auth")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        //  var command = new RegisterCommand(request.FirstName,request.LastName,request.Email,request.Password);
        var command = _mapper.Map<RegisterCommand>(request);
          var authResult = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        // var response = new AuthenticationResponse(
        //     authResult.user.UserId,
        //     authResult.user.FirstName,
        //     authResult.user.LastName,
        //     authResult.user.Email,
        //     authResult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // var query = new LoginQuery(request.Email, request.Password);
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        // var response = new AuthenticationResponse(
        //     authResult.user.UserId,
        //     authResult.user.FirstName,
        //     authResult.user.LastName,
        //     authResult.user.Email,
        //     authResult.Token);
        return Ok(response);
    }
    
  }
