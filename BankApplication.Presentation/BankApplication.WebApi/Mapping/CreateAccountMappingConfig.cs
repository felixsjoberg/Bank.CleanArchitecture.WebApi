using BankApplication.Application.Accounts;
using BankApplication.Application.Accounts.Response.Commands;
using BankApplication.Application.Customers;
using BankApplication.Application.Customers.Response.Commands;
using Mapster;

namespace BankApplication.Api.Mapping;

public class CreateAccountMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAccountResult, CreateAccountResponse>()
            .Map(dest => dest.AccountId, src => src.Account.AccountId)
            .Map(dest => dest.Frequency, src => src.Account.Frequency)
            .Map(dest => dest.Created, src => src.Account.Created)
            .Map(dest => dest.Balance, src => src.Account.Balance)
            .Map(dest => dest.AccountTypesId, src => src.Account.AccountTypesId);
    }
}


