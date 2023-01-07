using BankApplication.Domain.Aggregates;

namespace BankApplication.Application.Customers.Response.Commands;

public record AddAccountCreditResult(TransferAggregate Transfer);




