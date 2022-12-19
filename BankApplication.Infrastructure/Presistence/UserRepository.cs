using System;
using System.Data;
using BankApplication.Application.Persistence;
using Dapper;
using Domain.Domains;

namespace BankApplication.Infrastructure.Presistence;

public class UserRepository : IUserRepository
{

    private static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }


    //private readonly DapperContext _context;

    //public UserRepository(DapperContext context)
    //{
    //    _context = context;
    //}

    //public void Add(User user)
    //{
    //    // DbType.Int32, direction: ParameterDirection.InputOutput // if id creation by db.
    //    using (var db = _context.CreateConnection())
    //    {
    //    DynamicParameters parameters = new DynamicParameters();
    //    parameters.Add("@UserId", user.UserId);
    //    parameters.Add("@FirstName", user.FirstName);
    //    parameters.Add("@LastName", user.LastName);
    //    parameters.Add("@Email", user.Email);
    //    db.ExecuteScalar("AddUser", parameters, commandType: CommandType.StoredProcedure);
    //    }
    //}

    //public User? GetUserByEmail(string email)
    //{
    //    using (var db = _context.CreateConnection())
    //    {
    //        return db.QuerySingle("GetUserByEmail", new { email }, commandType: CommandType.StoredProcedure);
    //    }
    //}
}

