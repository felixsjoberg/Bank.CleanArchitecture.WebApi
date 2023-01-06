using BankApplication.Domain.Aggregates;

namespace BankApplication.Application.Customers.Response.Queries;

public record GetAccountByIdResult(IEnumerable<AccountAggregate> Account);


