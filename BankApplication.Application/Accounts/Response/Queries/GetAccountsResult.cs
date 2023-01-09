using Domain.Models;

namespace BankApplication.Application.Customers.Response.Queries;

public record GetAccountsResult(IEnumerable<Account> account);

