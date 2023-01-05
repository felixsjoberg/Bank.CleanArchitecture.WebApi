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

    public async Task<Account?> CreateAccount(Guid userId, string frequency)
    {
        using (var db = _context.CreateConnection())
        {
            try
            {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);
            parameters.Add("@frequency", frequency);
            var result= await db.QuerySingleAsync<Account>("CreateAccount", parameters, commandType: CommandType.StoredProcedure);
            return result;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public async Task<IEnumerable<AccountAggregate>> GetAccountById(int accountId)
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QueryAsync<AccountAggregate>("GetTransactionsByAccId", new { accountId }, commandType: CommandType.StoredProcedure);
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

