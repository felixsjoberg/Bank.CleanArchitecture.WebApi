using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Services.Queries.Login;
using BankApplication.Contracts.Authentication;
using BankApplication.Contracts.Customers;
using BankApplication.Infrastructure.Presistence;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        //var query = _mapper.Map<GetAccountsQuery>(request);
        var authResult = await _mediator.Send(query);

        var response = _mapper.Map<GetAccountsResponse>(authResult);

        return Ok(response);
    }
}
