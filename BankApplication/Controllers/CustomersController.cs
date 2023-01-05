using BankApplication.Application.Customers.Commands;
using BankApplication.Application.Customers.DTOs.Commands;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Queries.GetAccountById;
using BankApplication.Application.Customers.Queries.GetAccounts;
using BankApplication.Application.Services.Commands.Register;
using BankApplication.Contracts.Authentication;
using BankApplication.Contracts.Customers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers;


[Route("/Customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CustomersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateAccount(CreateAccountRequest request)
    {
        var command = _mapper.Map<CreateAccountCommand>(request);
        var authResult = await _mediator.Send(command);

        var response = _mapper.Map<CreateAccountResponse>(authResult);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccounts([FromQuery]GetAccountsRequest request)
    {
        var query = _mapper.Map<GetAccountsQuery>(request);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetAccountsResponse>(authResult);

        return Ok(response);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccountById([FromQuery]GetAccountByIdRequest request)
    {
        var query = _mapper.Map<GetAccountByIdQuery>(request);

        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetAccountByIdResponse>(authResult);

        return Ok(response);
    }
}
