using System;
namespace BankApplication.Contracts.Authentication;

public record LoginRequest(
string Email,
string Password);


