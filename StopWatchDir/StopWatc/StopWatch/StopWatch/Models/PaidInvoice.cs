using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class PaidInvoice
{
    public int InvoiceId { get; set; }

    public int VendorId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    public decimal InvoiceTotal { get; set; }

    public decimal PaymentTotal { get; set; }

    public decimal CreditTotal { get; set; }

    public int TermsId { get; set; }

    public DateOnly InvoiceDueDate { get; set; }

    public DateOnly? PaymentDate { get; set; }
}
