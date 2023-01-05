using System;
using System.Data;
using BankApplication.Application.Common.Errors;
using BankApplication.Application.Persistence;
using Dapper;
using Domain.Domains;

namespace BankApplication.Infrastructure.Presistence;

public class UserRepository : IUserRepository
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        using (var db = _context.CreateConnection())
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", user.UserId);
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);
            parameters.Add("@Password", user.Password);
            db.ExecuteScalar("AddUser", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        using (var db = _context.CreateConnection())
        {
            try
            {
                return await db.QuerySingleAsync<User>("GetUserByEmail", new { email }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

