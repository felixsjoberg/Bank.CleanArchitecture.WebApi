using System;
namespace BankApplication.Contracts.Authentication;

public record AuthenticationResponse(
		Guid userId,
		string FirstName,
		string LastName,
		string Email,
		string Token);