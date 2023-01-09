using System;
namespace BankApplication.Contracts.Transactions;

public record TransferResponse(
    string TransactionId,
    int RetrieverAccount,
    DateTime Date,
    string Operation,
    decimal Amount,
    decimal Balance,
    string SenderAccount
    );
