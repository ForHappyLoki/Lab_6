using System;
using System.Collections.Generic;

namespace Lab_6.Models;

public partial class ScheduleTvshow
{
    public int ScheduleTvshowId { get; set; }

    public int ScheduleId { get; set; }

    public int ShowId { get; set; }

    public int? SequenceNumber { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Tvshow Show { get; set; } = null!;
}
