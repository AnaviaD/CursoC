using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Sample
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string Color { get; set; } = null!;
}
