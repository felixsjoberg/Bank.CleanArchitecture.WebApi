using System;
using Domain.Domains;

namespace BankApplication.Application.Authentication;

public record AuthenticationResult(
    User User,
    string token
    );

