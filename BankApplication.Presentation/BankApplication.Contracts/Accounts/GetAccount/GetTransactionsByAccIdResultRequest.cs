using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Accounts;

public record GetTransactionsByAccIdResultRequest([Required]int AccountId);


