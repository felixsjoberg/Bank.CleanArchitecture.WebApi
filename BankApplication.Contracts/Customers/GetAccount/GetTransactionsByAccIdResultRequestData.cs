using System;
namespace BankApplication.Contracts.Customers;

public record GetTransactionsByAccIdResultRequestData(
    Guid UserId,
    int AccountId);


