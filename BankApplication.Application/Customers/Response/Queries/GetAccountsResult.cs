using Domain.Models;

namespace BankApplication.Application.Customers.Queries;

public record GetAccountsResult(List<Account> account);

