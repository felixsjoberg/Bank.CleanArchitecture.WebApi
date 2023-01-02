using System;
using BankApplication.Application.Authentication.Common;
using BankApplication.Application.Customers.Queries;
using BankApplication.Contracts.Authentication;
using Mapster;

namespace BankApplication.Api.Mapping;

public class GetAccountsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAccountsResult, GetAccountsResponse>()
            .Map(dest => dest, src => src.account);
            //.Map(dest => dest.AccountType, src => src.account.Select(c => c.AccountTypes))
            //.Map(dest => dest.Created, src => src.account.Select(c => c.Created))
            //.Map(dest => dest.Balance, src => src.account.Select(c => c.Balance));
    }
}
