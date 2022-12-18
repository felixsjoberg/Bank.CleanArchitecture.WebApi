using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Card
{
    public int CardId { get; set; }

    public int DispositionId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime Issued { get; set; }

    public string Cctype { get; set; } = null!;

    public string Ccnumber { get; set; } = null!;

    public string Cvv2 { get; set; } = null!;

    public int ExpM { get; set; }

    public int ExpY { get; set; }

    public virtual Disposition Disposition { get; set; } = null!;
}
