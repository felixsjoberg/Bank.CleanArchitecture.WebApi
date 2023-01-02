using System;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Response.Commands;
using MediatR;

namespace BankApplication.Application.Customers.Commands;

public record PostTransactionCommand : IRequest<PostTransactionResult>;



