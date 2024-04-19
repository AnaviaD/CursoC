using System;
using System.Collections.Generic;

namespace StopWatch.Models;

public partial class AssignmentRecord
{
    public string Id { get; set; } = null!;

    public string? AssigmentId { get; set; }

    public DateTime InitH { get; set; }

    public DateTime FinishH { get; set; }

    public string? TotalTime { get; set; }

    public virtual Assignment? Assigment { get; set; }
}
