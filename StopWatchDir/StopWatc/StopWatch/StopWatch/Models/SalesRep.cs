using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class SalesRep
{
    public int RepId { get; set; }

    public string RepFirstName { get; set; } = null!;

    public string RepLastName { get; set; } = null!;

    public virtual ICollection<SalesTotal> SalesTotals { get; set; } = new List<SalesTotal>();
}
