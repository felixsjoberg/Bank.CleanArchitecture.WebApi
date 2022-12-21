using System;
using BankApplication.Application.Authentication.Common;

namespace BankApplication.Application.Authentication.Queries;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string email, string password);
}

