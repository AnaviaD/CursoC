using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Apflat
{
    public string VendorName { get; set; } = null!;

    public string InvoiceNumber { get; set; } = null!;

    public string? ItemDescription1 { get; set; }

    public string? ItemDescription2 { get; set; }

    public string? ItemDescription3 { get; set; }

    public string? ItemDescription4 { get; set; }
}
