using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Customers;

public record TransferRequest(
    [Required]
    Guid UserId,
    [Required]
    int AccountId,
    [Range(1,2)]
    int Operation,
    [Required]
    decimal Amount,
    [Required]
    string Account);


