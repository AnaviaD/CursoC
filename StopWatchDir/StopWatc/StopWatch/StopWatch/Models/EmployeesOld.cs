using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class EmployeesOld
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int DeptNo { get; set; }
}
