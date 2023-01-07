using BankApplication.Application.Customers;
using BankApplication.Application.Customers.Response.Queries;
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
