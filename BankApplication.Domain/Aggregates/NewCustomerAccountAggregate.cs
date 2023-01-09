using System;
using Domain.Domains;
using Domain.Models;

namespace BankApplication.Domain.Aggregates;



public class NewCustomerAccountAggregate
{
    public int DispositionId { get; set; }

    public int CustomerId { get; set; }

    public int AccountId { get; set; }

    public Guid UserId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual User? User { get; set; } = null!;
}

