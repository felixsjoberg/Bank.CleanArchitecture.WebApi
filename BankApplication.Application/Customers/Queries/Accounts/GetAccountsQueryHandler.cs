using System;
using BankApplication.Application.Authentication.Common;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Persistence;
using BankApplication.Application.Services.Queries.Login;
using Domain.Domains;
using MediatR;


namespace BankApplication.Application.Customers.Queries;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, GetAccountsResult>
{
    private readonly ICustomersRepository _customerRepository;

    public GetAccountsQueryHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetAccountsResult> Handle(GetAccountsQuery query, CancellationToken cancellationToken)
    {
        if (query.userId == Guid.Empty)
        {
            throw new InvalidUser();
        }
        var result = await _customerRepository.GetAccounts(query.userId);

        return new GetAccountsResult(result);
        
    }

}
