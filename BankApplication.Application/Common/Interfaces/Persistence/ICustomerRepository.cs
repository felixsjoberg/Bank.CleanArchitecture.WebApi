using BankApplication.Application.Customers.Commands.AddAccountCredit;
using BankApplication.Domain.Aggregates;
using Domain.Domains;

namespace BankApplication.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task<NewCustomerAccountAggregate> NewCustomerAccount(User user, NewCustomerAccountCommand command);
}