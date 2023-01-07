using System;
using BankApplication.Application.Adminstrator;
using BankApplication.Application.Adminstrator.Response.Commands;
using BankApplication.Application.Customers.Response.Commands;
using Mapster;

namespace BankApplication.Api.Mapping;

public class NewCustomerAccountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<NewCustomerAccountResult, NewCustomerAccountResponse>()
            .Map(dest => dest.TransactionId, src => src.Transfer.TransactionId)
            .Map(dest => dest.RetrieverAccount, src => src.Transfer.AccountId)
            .Map(dest => dest.Date, src => src.Transfer.Date)
            .Map(dest => dest.Operation, src => src.Transfer.Operation)
            .Map(dest => dest.Amount, src => src.Transfer.Amount)
            .Map(dest => dest.Balance, src => src.Transfer.Balance);
    }
}

