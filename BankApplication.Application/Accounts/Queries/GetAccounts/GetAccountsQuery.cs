using System;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Accounts.Queries.GetAccounts;

public record GetAccountsQuery(Guid UserId) : IRequest<GetAccountsResult>;
