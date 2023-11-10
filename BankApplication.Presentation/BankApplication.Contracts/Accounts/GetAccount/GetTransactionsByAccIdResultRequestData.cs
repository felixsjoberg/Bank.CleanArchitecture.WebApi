using System;
namespace BankApplication.Contracts.Accounts;

public record GetTransactionsByAccIdResultRequestData(
    Guid UserId,
    int AccountId);


