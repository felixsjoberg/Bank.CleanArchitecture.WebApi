using System;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Accounts.Queries.GetAccountById;

public record GetTransactionsByAccIdQuery(Guid UserId, int AccountId) : IRequest <GetTransactionsByAccIdResult>;


