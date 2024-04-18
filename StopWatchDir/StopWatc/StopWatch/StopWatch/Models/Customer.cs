using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string? CustomerLast { get; set; }

    public string? CustomerFirst { get; set; }

    public string? CustAddr { get; set; }

    public string? CustCity { get; set; }

    public string? CustState { get; set; }

    public string? CustZip { get; set; }

    public string? CustPhone { get; set; }
}
