using BankApplication.Application.Authentication.Common;
using MediatR;

namespace BankApplication.Application.Services.Commands.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string Role): IRequest<AuthenticationResult>;

