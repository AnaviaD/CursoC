using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class Assignment
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Difficulty { get; set; }

    public virtual ICollection<AssignmentRecord> AssignmentRecords { get; set; } = new List<AssignmentRecord>();
}
