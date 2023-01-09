using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Transactions;

public record TransferRequest(
    [Required]
    int AccountId,
    [Range(1,2)]
    int Operation,
    [Required]
    decimal Amount,
    [Required]
    string Account);


