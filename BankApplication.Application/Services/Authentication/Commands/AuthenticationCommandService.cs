using System;
using BankApplication.Application.Authentication.Common;
using BankApplication.Application.Common.Interfaces;
using BankApplication.Application.Persistence;
using Domain.Domains;

namespace BankApplication.Application.Authentication.Commands; 

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //validate so that user doesn't exists
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User Email already exists.");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

       var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

}

