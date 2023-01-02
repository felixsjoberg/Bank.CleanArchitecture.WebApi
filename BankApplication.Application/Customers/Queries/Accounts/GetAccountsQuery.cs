using System;
using MediatR;

namespace BankApplication.Application.Customers.Queries;

public record GetAccountsQuery(Guid userId) : IRequest<GetAccountsResult>;
