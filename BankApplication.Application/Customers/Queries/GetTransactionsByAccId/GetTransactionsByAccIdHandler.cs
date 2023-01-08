using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Queries.GetAccountById;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Customers.Queries.GetTransactionsByAccId;

public class GetAccountByIdHandler : IRequestHandler<GetTransactionsByAccIdQuery, GetTransactionsByAccIdResult>
{
    private readonly ICustomersRepository _customerRepository;

    public GetAccountByIdHandler(ICustomersRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<GetTransactionsByAccIdResult> Handle(GetTransactionsByAccIdQuery query, CancellationToken cancellationToken)
    {
        if (query.AccountId == 0)
        {
            throw new InvalidAccount();
        }
        var result = await _customerRepository.GetTransactionsByAccId(query.UserId,query.AccountId);
        if (result.Count() == 0)
        {
            throw new InvalidAccount();
        }
        return new GetTransactionsByAccIdResult(result);

    }

}

