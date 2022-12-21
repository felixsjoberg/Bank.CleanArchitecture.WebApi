using BankApplication.Application.Authentication.Commands;
using BankApplication.Application.Authentication.Common;
using BankApplication.Application.Common.Interfaces;
using BankApplication.Application.Persistence;
using Domain.Domains;

namespace BankApplication.Application.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User doesn't exist");
        }

        
        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
        
    }
}

