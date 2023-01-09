using System;
using BankApplication.Domain.Aggregates;

namespace BankApplication.Application.Accounts.Response.Commands;

public record TransferResult(TransferAggregate Transfer);


