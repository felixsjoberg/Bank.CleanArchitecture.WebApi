using System;
using BankApplication.Application.Common.Errors;
using System.Data;
using BankApplication.Application.Common.Interfaces.Persistence;
using BankApplication.Domain.Aggregates;
using Dapper;

namespace BankApplication.Infrastructure.Presistence;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly DapperContext _context;

    public TransactionsRepository(DapperContext context)
    {
        _context = context;
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
                if (validTransfer > 0)
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

