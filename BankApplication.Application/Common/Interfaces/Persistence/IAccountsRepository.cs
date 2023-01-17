using System;
using BankApplication.Domain.Aggregates;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface IAccountsRepository
{
    Task<Account?> CreateAccount(Guid userId,string frequency, int AccountTypesId, int? CustomerId);
    Task<IEnumerable<Account>>GetAccounts(Guid userId);
}

