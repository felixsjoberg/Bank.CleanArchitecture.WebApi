using System;
using System.ComponentModel.DataAnnotations;

namespace BankApplication.Contracts.Authentication;

public record RegisterRequest(
	[Required]
	string Email,
	[Required]
    string Password,
	[Required]
    string Role
);

