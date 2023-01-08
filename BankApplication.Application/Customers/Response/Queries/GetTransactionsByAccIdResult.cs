using BankApplication.Domain.Aggregates;

namespace BankApplication.Application.Customers.Response.Queries;

public record GetTransactionsByAccIdResult(IEnumerable<AccountAggregate> Account);


