using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Customers;

public record CreateAccountRequest(
    [Required]
    string Frequency);


