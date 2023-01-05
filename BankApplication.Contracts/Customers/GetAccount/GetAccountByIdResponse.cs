using System;
namespace BankApplication.Contracts.Customers;

public record GetAccountByIdResponse(
    // int AccountId,
    //int AccountTypesId,
    //DateTime Created,
    //string Frequency,
    //decimal Balance,
    List<AccountTransactionsResponse> Transactions);

public record AccountTransactionsResponse(
    string Account,
    int TransactionId,
    DateTime Date,
    string Type,
    string Operation,
    decimal Amount,
    decimal Balance
    );

