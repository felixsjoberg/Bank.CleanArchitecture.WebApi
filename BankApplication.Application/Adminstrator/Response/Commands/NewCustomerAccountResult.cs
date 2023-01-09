using System;
using BankApplication.Domain.Aggregates;

namespace BankApplication.Application.Adminstrator.Response.Commands;

public record NewCustomerAccountResult(NewCustomerAccountAggregate DispositionCustomerAccount);

