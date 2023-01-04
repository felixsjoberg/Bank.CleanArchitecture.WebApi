using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Queries.GetAccountById;
using BankApplication.Application.Customers.Queries.GetAccounts;
using BankApplication.Contracts.Customers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers;


[Route("/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CustomersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAccounts(GetAccountsRequest request)
    {
        var query = new GetAccountsQuery(request.userId);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetAccountsResponse>(authResult);

        return Ok(response);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetAccountById([FromQuery]GetAccountByIdRequest request)
    {
        var query = new GetAccountByIdQuery(request.AccountId);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetAccountByIdResponse>(authResult);

        return Ok(response);
    }
}
