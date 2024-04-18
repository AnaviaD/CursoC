using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Investor
{
    public int InvestorId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? Phone { get; set; }

    public decimal? Investments { get; set; }

    public decimal? NetGain { get; set; }
}
