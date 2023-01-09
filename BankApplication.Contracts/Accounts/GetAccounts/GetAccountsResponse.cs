namespace BankApplication.Application.Accounts;

public record GetAccountsResponse(
    List<AccountsListResponse> Accounts);

public record AccountsListResponse(
    int AccountId,
    int AccountTypesId,
    DateTime Created,
    string Frequency,
    decimal Balance);

