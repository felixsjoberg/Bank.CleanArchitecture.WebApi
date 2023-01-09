using BankApplication.Application.Accounts.Response.Commands;
using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Accounts.Commands;

public record CreateAccountCommand(
    Guid UserId,
    string Frequency,
    int AccountTypesId
    ) : IRequest<CreateAccountResult>;