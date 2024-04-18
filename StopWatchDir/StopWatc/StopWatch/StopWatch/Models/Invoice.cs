using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int? InvoiceNumber { get; set; }

    public decimal? InvoiceTotal { get; set; }
}
