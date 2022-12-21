using BankApplication.Application.Authentication.Common;
using MediatR;

namespace BankApplication.Application.Services.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<AuthenticationResult>; //What will be returned

