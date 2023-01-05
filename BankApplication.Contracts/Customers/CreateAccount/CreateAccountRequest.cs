using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Customers;

public record CreateAccountRequest(
    [Required]
    Guid UserId,
    [Required]
    string Frequency);


