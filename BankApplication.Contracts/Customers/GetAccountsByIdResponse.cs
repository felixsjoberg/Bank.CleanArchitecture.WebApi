using System;
namespace BankApplication.Contracts.Customers;

public record GetAccountsByIdResponse(AccountResponse Account);

public record AccountResponse(
    int AccountId,
    int AccountTypesId,
    DateTime Created,
    string Frequency,
    decimal Balance);

