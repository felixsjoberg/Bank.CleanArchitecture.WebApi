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

    public async Task<Account> GetAccountById(int accountId)
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QuerySingleAsync<Account>("GetAccountById", new { accountId }, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<Account>> GetAccounts(Guid userId)
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QueryAsync<Account>("GetAccounts", new { userId }, commandType: CommandType.StoredProcedure);
        }
    }

    public Task<Account> PostTransaction(int accountId)
    {
        throw new NotImplementedException();
    }
}

