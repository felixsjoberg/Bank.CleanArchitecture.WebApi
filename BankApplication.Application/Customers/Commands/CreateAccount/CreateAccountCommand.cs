using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands;

public record CreateAccountCommand(
    Guid UserId,
    string Frequency
    ) : IRequest<CreateAccountResult>;