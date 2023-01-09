using BankApplication.Application.Accounts.Queries.GetAccountById;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Accounts.Queries.GetTransactionsByAccId;

public class GetAccountByIdHandler : IRequestHandler<GetTransactionsByAccIdQuery, GetTransactionsByAccIdResult>
{
    private readonly IAccountsRepository _AccountsRepository;

    public GetAccountByIdHandler(IAccountsRepository customerRepository)
    {
        _AccountsRepository = customerRepository;
    }

    public async Task<GetTransactionsByAccIdResult> Handle(GetTransactionsByAccIdQuery query, CancellationToken cancellationToken)
    {
        if (query.AccountId == 0)
        {
            throw new InvalidAccount();
        }
        var result = await _AccountsRepository.GetTransactionsByAccId(query.UserId,query.AccountId);
        if (result.Count() == 0)
        {
            throw new InvalidAccount();
        }
        return new GetTransactionsByAccIdResult(result);

    }

}

