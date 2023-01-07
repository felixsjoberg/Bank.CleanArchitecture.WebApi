using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Adminstrator;

public record NewCustomerAccountRequest(
    [Required]
    int AccountId,
    decimal Amount);


