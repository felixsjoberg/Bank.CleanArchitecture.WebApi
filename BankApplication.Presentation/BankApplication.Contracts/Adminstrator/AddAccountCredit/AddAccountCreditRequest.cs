using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Adminstrator;

public record AddAccountCreditRequest(
    [Required]
    int AccountId,
    decimal Amount);


