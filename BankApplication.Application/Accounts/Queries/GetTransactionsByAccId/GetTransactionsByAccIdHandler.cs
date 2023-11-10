using BankApplication.Application.Accounts.Queries.GetAccountById;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Accounts.Queries.GetTransactionsByAccId;

public class GetAccountByIdHandler : IRequestHandler<GetTransactionsByAccIdQuery, GetTransactionsByAccIdResult>
{
    private readonly ITransactionsRepository _TransactionsRepository;

    public GetAccountByIdHandler(ITransactionsRepository transactionsRepository)
    {
        _TransactionsRepository = transactionsRepository;
    }

    public async Task<GetTransactionsByAccIdResult> Handle(GetTransactionsByAccIdQuery query, CancellationToken cancellationToken)
    {
        if (query.AccountId == 0)
        {
            // return notfound
            throw new InvalidAccount();
        }
        var result = await _TransactionsRepository.GetTransactionsByAccId(query.UserId,query.AccountId);
        if (result is null)
        {
            throw new InvalidAccount();
        }
        return new GetTransactionsByAccIdResult(result);

    }

}

