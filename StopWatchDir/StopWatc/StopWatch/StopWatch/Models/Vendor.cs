using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string? VendorAddress1 { get; set; }

    public string? VendorAddress2 { get; set; }

    public string VendorCity { get; set; } = null!;

    public string VendorState { get; set; } = null!;

    public string VendorZipCode { get; set; } = null!;

    public string? VendorContactLname { get; set; }

    public string? VendorContactFname { get; set; }

    public string? VendorPhone { get; set; }

    public int TermsId { get; set; }

    public int AccountNo { get; set; }

    public DateOnly? LastTranDate { get; set; }

    public decimal? Ytdpurchases { get; set; }

    public decimal? Ytdreturns { get; set; }

    public decimal? LastYtdpurchases { get; set; }

    public decimal? LastYtdreturns { get; set; }
}
