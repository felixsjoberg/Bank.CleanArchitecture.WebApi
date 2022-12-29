using System;
using Domain.Domains;

namespace BankApplication.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}

