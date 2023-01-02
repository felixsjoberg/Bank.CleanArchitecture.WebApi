using System;
using Domain.Domains;
using Domain.Models;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface ICustomersRepository
{
    Task <List<Account>>GetAccounts(Guid userId);
    Task<Account>GetAccountById(Account accountId);
    Task<Account>PostTransaction(Account accountId);    
}

