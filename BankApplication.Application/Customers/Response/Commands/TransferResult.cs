using System;
using BankApplication.Domain.Aggregates;

namespace BankApplication.Application.Customers.Response.Commands;

public record TransferResult(TransferAggregate Transfer);


