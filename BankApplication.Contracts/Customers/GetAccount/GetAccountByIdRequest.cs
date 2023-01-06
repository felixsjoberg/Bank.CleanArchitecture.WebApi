using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Customers;

public record GetAccountByIdRequest([Required]int AccountId);


