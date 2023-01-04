using System;
using BankApplication.Application.Authentication.Common;
using BankApplication.Application.Customers.Queries;
using BankApplication.Application.Customers.Response.Queries;
using BankApplication.Contracts.Authentication;
using BankApplication.Contracts.Customers;
using System.Linq;
using Mapster;

namespace BankApplication.Api.Mapping;

public class GetAccountByIdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetAccountByIdResult, GetAccountByIdResponse>()
            .Map(dest => dest.Transactions, src => src.Account);

    }
}
