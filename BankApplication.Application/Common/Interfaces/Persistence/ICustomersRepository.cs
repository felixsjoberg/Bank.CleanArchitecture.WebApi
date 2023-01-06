using System;
using BankApplication.Domain.Aggregates;
using Domain.Domains;
using Domain.Models;
using MediatR;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface ICustomersRepository
{
    Task<Account?> CreateAccount(Guid userId,string frequency);
    Task<IEnumerable<Account>>GetAccounts(Guid userId);
    Task<IEnumerable<AccountAggregate>> GetAccountById(int accountId);
    Task<TransferAggregate>Transfer(Guid userId,int accountId,string operation, decimal amount,string account);
}

