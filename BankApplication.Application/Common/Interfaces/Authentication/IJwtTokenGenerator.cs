using System;
using Domain.Domains;

namespace BankApplication.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

