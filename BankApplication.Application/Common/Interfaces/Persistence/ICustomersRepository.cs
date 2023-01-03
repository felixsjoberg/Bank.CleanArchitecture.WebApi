using System;
using Domain.Domains;
using Domain.Models;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface ICustomersRepository
{
    Task <IEnumerable<Account>>GetAccounts(Guid userId);
    Task<Account>GetAccountById(int accountId);
    Task<Account>PostTransaction(int accountId);    
}

