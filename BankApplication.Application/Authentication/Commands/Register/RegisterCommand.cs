using BankApplication.Application.Authentication.Common;
using MediatR;

namespace BankApplication.Application.Services.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password): IRequest<AuthenticationResult>; //What will be returned

