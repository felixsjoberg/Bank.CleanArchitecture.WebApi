using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Customers;

public record GetTransactionsByAccIdResultRequest([Required]int AccountId);


