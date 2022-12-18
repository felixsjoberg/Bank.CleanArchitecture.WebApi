using System;
using Domain.Models;

namespace Domain.Domains;

public class Users
{
	public int UserId { get; set; }

	public string? UserName { get; set; }

	public string? Password { get; set; }

	public List<Account> Accounts = new List<Account>();
}

