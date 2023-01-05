using System;
using Domain.Domains;
using Domain.Models;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface ICustomersRepository
{
    Task<Account?> CreateAccount(Guid userId,string frequency);
    Task<IEnumerable<Account>>GetAccounts(Guid userId);
    Task<IEnumerable<AccountAggregate>> GetAccountById(int accountId);
    Task<Account>PostTransaction(int accountId);    
}

