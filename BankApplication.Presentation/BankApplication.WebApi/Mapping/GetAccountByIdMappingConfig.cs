using BankApplication.Application.Customers.Response.Queries;
using BankApplication.Contracts.Accounts;
using Mapster;

namespace BankApplication.Api.Mapping;

public class GetAccountByIdMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<GetTransactionsByAccIdResult, GetTransactionsByAccIdResultResponse>()
            .Map(dest => dest.Transactions, src => src.Account);

    }
}
