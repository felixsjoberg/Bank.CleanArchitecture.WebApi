using System;
namespace BankApplication.Contracts.Customers;

public record TransferRequestData(
    Guid UserId,
    int AccountId,
    int Operation,
    decimal Amount,
    string Account);


