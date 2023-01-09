using System;
using System.Collections.Generic;
using Domain.Domains;

namespace Domain.Models;

public partial class Disposition
{
    public int DispositionId { get; set; }

    public int CustomerId { get; set; }

    public int AccountId { get; set; }

    public Guid UserId { get; set; }

    public string Type { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Card> Cards { get; } = new List<Card>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual User? User { get; set; }

}
