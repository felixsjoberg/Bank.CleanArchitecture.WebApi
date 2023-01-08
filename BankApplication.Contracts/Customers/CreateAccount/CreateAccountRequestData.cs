using System;
namespace BankApplication.Contracts.Customers;

public record CreateAccountRequestData(
    Guid UserId,
    string Frequency);


