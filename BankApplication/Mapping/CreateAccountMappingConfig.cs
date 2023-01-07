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
            .Map(dest => dest.UserId, src => src.Account.User.UserId);
    }
}


