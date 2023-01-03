using System;
using BankApplication.Application.Authentication.Common;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Response.Queries;
using BankApplication.Contracts.Authentication;
using Mapster;

namespace BankApplication.Api.Mapping;

public class GetAccountsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAccountsResult, GetAccountsResponse>()
            .Map(dest => dest.Accounts, src => src.account);
    }
}
