using System;
using BankApplication.Application.Authentication.Common;

namespace BankApplication.Application.Authentication.Commands;

public interface IAuthenticationCommandService
{
    AuthenticationResult Register(string firstName, string lastName, string email, string password);

}

