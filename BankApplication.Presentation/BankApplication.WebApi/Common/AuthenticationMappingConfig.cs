using System.Threading;
using BankApplication.Application.Authentication.Common;
using BankApplication.Contracts.Authentication;
using Mapster;

namespace BankApplication.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config) 
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest.Token, src => src.Token)
        .Map(dest => dest, src => src.user);
    }
}