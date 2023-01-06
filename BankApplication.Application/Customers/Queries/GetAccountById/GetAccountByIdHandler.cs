using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Customers.Queries.GetAccountById;

public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, GetAccountByIdResult>
{
    private readonly ICustomersRepository _customerRepository;

    public GetAccountByIdHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetAccountByIdResult> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
    {
        if (query.AccountId == 0)
        {
            throw new InvalidAccount();
        }
        var result = await _customerRepository.GetAccountById(query.AccountId);

        return new GetAccountByIdResult(result);

    }

}

