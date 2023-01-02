namespace BankApplication.Application.Customers.Queries;

public record GetAccountsResponse(
    int Account,
    int AccountType,
    DateTime Created,
    string Frequency,
    decimal Balance);


