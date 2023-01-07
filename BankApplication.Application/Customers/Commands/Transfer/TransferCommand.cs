using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands;

public record TransferCommand(
    Guid UserId,
    int AccountId,
    int Operation,
    decimal Amount,
    string Account) : IRequest<TransferResult>;



