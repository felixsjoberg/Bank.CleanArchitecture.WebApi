using System;
using BankApplication.Application.Customers.DTOs.Commands;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Response.Commands;
using BankApplication.Application.Customers.Response.Queries;
using Mapster;

namespace BankApplication.Api.Mapping;

public class TransferMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TransferResult, TransferResponse>()
            .Map(dest => dest.TransactionId, src => src.Transfer.TransactionId)
            .Map(dest => dest.RetrieverAccount, src => src.Transfer.AccountId)
            .Map(dest => dest.Date, src => src.Transfer.Date)
            .Map(dest => dest.Operation, src => src.Transfer.Operation)
            .Map(dest => dest.Amount, src => src.Transfer.Amount)
            .Map(dest => dest.Balance, src => src.Transfer.Balance)
            .Map(dest => dest.SenderAccount, src => src.Transfer.Account);
    }
}

