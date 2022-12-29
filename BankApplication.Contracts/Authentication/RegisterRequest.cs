using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Authentication;

public record RegisterRequest(
    [Required]
    string FirstName,
    [Required]
	string LastName,
	[Required]
	string Email,
	[Required]
    string Password
);

