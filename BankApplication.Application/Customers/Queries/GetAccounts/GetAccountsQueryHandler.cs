using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;


namespace BankApplication.Application.Customers.Queries.GetAccounts;

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
