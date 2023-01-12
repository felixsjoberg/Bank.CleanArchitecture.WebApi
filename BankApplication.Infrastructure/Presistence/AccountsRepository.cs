using System.Data;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Domain.Aggregates;
using Dapper;
using Domain.Models;

namespace BankApplication.Infrastructure.Presistence;

public class AccountsRepository : IAccountsRepository
{
    private readonly DapperContext _context;

    public AccountsRepository(DapperContext context)
    {
        _context = context;
    }


    public async Task<Account?> CreateAccount(Guid userId, string frequency, int AccountTypesId, int? CustomerId)
    {
        using (var db = _context.CreateConnection())
        {
            try
            {
            //var customerId = await db.QuerySingleAsync<int>("GetCustomerIdDispostion", new {userId}, commandType: CommandType.StoredProcedure);

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@customerId", CustomerId);
            parameters.Add("@userId", userId);
            parameters.Add("@frequency", frequency);
            parameters.Add("@accountTypesId", AccountTypesId);
                var result= await db.QuerySingleAsync<Account>("CreateAccount", parameters, commandType: CommandType.StoredProcedure);
            return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public async Task<IEnumerable<AccountAggregate>> GetTransactionsByAccId(Guid userId,int accountId)
    {
        using (var db = _context.CreateConnection())
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@userId", userId);
            parameters.Add("@accountId", accountId);
            return await db.QueryAsync<AccountAggregate>("GetTransactionsByAccId", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<Account>> GetAccounts(Guid userId)
    {
        using (var db = _context.CreateConnection())
        {
            return await db.QueryAsync<Account>("GetAccounts", new { userId }, commandType: CommandType.StoredProcedure);
        }
    }
}

