using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int DeptNo { get; set; }

    public int? ManagerId { get; set; }
}
