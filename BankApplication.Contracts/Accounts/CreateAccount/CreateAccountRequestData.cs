using System;
namespace BankApplication.Contracts.Accounts;

public record CreateAccountRequestData(
    Guid UserId,
    string Frequency,
    int AccountTypesId);


