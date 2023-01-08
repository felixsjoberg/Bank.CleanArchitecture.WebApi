using BankApplication.Application.Adminstrator.Response.Commands;
using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands.AddAccountCredit;

public record NewCustomerAccountCommand(
    Guid UserId,
    int AccountId,
    int Operation,
    decimal Amount,
    string Account
    ) : IRequest<NewCustomerAccountResult>;