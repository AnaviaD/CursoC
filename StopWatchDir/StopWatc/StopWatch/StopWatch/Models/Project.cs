using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Project
{
    public string ProjectNo { get; set; } = null!;

    public int EmployeeId { get; set; }
}
