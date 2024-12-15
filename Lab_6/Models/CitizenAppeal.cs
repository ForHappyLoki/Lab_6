﻿using System;
using System.Collections.Generic;

namespace Lab_6.Models;

public partial class CitizenAppeal
{
    public int AppealId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Organization { get; set; }

    public string Purpose { get; set; } = null!;

    public int? ShowId { get; set; }

    public DateTime? DateAppeal { get; set; }

    public virtual Tvshow? Show { get; set; }
}
