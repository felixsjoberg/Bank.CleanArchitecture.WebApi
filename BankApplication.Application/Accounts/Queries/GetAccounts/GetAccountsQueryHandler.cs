using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;


namespace BankApplication.Application.Accounts.Queries.GetAccounts;

public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, GetAccountsResult>
{
    private readonly IAccountsRepository _AccountsRepository;

    public GetAccountsQueryHandler(IAccountsRepository customerRepository)
    {
        _AccountsRepository = customerRepository;
    }

    public async Task<GetAccountsResult> Handle(GetAccountsQuery query, CancellationToken cancellationToken)
    {
        if (query.UserId == Guid.Empty)
        {
            throw new InvalidUser();
        }
        var result = await _AccountsRepository.GetAccounts(query.UserId);

        return new GetAccountsResult(result);
        
    }

}
