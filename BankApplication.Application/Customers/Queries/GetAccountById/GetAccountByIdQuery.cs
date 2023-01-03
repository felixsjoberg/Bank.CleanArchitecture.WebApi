using System;
using BankApplication.Application.Customers.Response.Queries;
using MediatR;

namespace BankApplication.Application.Customers.Queries.GetAccountById;

public record GetAccountByIdQuery(int AccountId) : IRequest <GetAccountByIdResult>;


