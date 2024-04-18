using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class SalesTotal
{
    public int RepId { get; set; }

    public string SalesYear { get; set; } = null!;

    public decimal SalesTotal1 { get; set; }

    public virtual SalesRep Rep { get; set; } = null!;
}
