using System;
namespace BankApplication.Contracts.Transactions;

public record TransferRequestData(
    Guid UserId,
    int AccountId,
    int Operation,
    decimal Amount,
    string Account);


