using BankApplication.Api.Service;
using BankApplication.Application.Accounts;
using BankApplication.Application.Accounts.Commands;
using BankApplication.Application.Accounts.Queries.GetAccountById;
using BankApplication.Application.Accounts.Queries.GetAccounts;
using BankApplication.Application.Transactions.Commands.Transfer;
using BankApplication.Contracts.Accounts;
using BankApplication.Contracts.Transactions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers;


[Route("/Customers")]
[Authorize(Roles = "customer")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly JwtService _jwtService;

    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CustomersController(IMediator mediator, IMapper mapper,JwtService jwtService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateAccount(CreateAccountRequest request)
    {
        // API act as client, login function replicate regular login system therefore extract JWT.
        Guid userId = _jwtService.ExtractJwt();
        var requestData = new CreateAccountRequestData(userId,request.Frequency,request.AccountTypesId);

        var command = _mapper.Map<CreateAccountCommand>(requestData);
        var authResult = await _mediator.Send(command);

        var response = _mapper.Map<CreateAccountResponse>(authResult);

        return Ok(response);
    }

    [HttpPost("transfer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Transfer(TransferRequest request)
    {
        // API act as client, login function replicate regular login system therefore extract JWT.
        Guid userId = _jwtService.ExtractJwt();
        var requestData = new TransferRequestData(userId, request.AccountId, request.Operation, request.Amount, request.Account);

        var command = _mapper.Map<TransferCommand>(requestData);
        var authResult = await _mediator.Send(command);

        var response = _mapper.Map<TransferResponse>(authResult);

        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAccounts()
    {
        Guid UserId = _jwtService.ExtractJwt();
        var request = new GetAccountsRequest(UserId);

        var query = _mapper.Map<GetAccountsQuery>(request);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetAccountsResponse>(authResult);

        return Ok(response);
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTransactionsByAccId([FromQuery]GetTransactionsByAccIdResultRequest request)
    {
        Guid userId = _jwtService.ExtractJwt();

        var requestData = new GetTransactionsByAccIdResultRequestData(userId, request.AccountId);

        var query = _mapper.Map<GetTransactionsByAccIdQuery>(requestData);

        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetTransactionsByAccIdResultResponse>(authResult);

        return Ok(response);
    }
}
