using System;
using Domain.Domains;

namespace BankApplication.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string token
    );

