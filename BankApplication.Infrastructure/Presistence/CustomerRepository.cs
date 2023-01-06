using System.Data;
using System.Data.Common;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Domain.Aggregates;
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

    public async Task<TransferAggregate> Transfer(Guid userId, int accountId, string operation, decimal amount, string account)
    {
        using (var db = _context.CreateConnection())
        {
            try
            {
                //Validate owner of account & that it exist.
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AccountId", accountId);
                dynamicParameters.Add("@UserId", userId);
                var validTransfer = await db.ExecuteAsync("IsValidTransfer", dynamicParameters, commandType: CommandType.StoredProcedure);
                if (validTransfer <0)
                {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@accountId", accountId);
                        parameters.Add("@operation", operation);
                        parameters.Add("@transferAmount", amount);
                        parameters.Add("@destinationAccountNumber", account);

                        var result = await db.QueryFirstOrDefaultAsync<TransferAggregate>("Transfer", parameters, commandType: CommandType.StoredProcedure);
                        if (result is null)
                        {
                            throw new InsufficientFunds();
                        }
                        return result;
                }
            }
            catch (Exception)
            {
            throw new InvalidTransfer();
            }
            throw new InvalidTransfer();
        }
    }
}

