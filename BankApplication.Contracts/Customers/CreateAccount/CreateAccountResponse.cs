using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Application.Customers.DTOs.Commands;

public record CreateAccountResponse(
        int AccountId,
        string Frequency,
        DateTime Created,
        decimal Balance,
        Guid UserId);


