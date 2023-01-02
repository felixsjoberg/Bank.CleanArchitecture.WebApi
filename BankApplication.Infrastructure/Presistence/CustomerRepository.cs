using System;
using System.Data;
using BankApplication.Application.Common.Interfaces.Persistence;
using Dapper;
using Domain.Domains;
using Domain.Models;

namespace BankApplication.Infrastructure.Presistence;

public class CustomerRepository : ICustomersRepository
{
    private readonly DapperContext _context;

    public CustomerRepository(DapperContext context)
    {
        _context = context;
    }

    public Task<Account> GetAccountById(Account accountId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Account>> GetAccounts(Guid userId)
    {
        using (var db = _context.CreateConnection())
        {
            return (List<Account>)await db.QueryAsync<Account>("GetAccounts", new { userId }, commandType: CommandType.StoredProcedure);
        }
    }

    public Task<Account> PostTransaction(Account accountId)
    {
        throw new NotImplementedException();
    }
}

