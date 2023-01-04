using System;
using Domain.Models;

namespace BankApplication.Application.Customers.Response.Queries;

public record GetAccountByIdResult(IEnumerable<AccountAggregate> Account);


