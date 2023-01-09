using BankApplication.Domain.Aggregates;
using Domain.Models;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface IAdminstratorRepository
{
    Task<TransferAggregate> AddAccountCredit(int accountId,decimal amount);
}