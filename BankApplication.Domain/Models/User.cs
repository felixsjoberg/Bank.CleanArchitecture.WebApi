using System;
using Domain.Models;

namespace Domain.Domains;

public class User
{
    public Guid UserId { get; set; } = Guid.NewGuid();

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public List<Account> Accounts = new List<Account>();
}

