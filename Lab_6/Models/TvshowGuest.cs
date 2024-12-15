using System;
using System.Collections.Generic;

namespace Lab_6.Models;

public partial class TvshowGuest
{
    public int ShowId { get; set; }

    public int GuestId { get; set; }

    public int TvshowGuestId { get; set; }

    public virtual Guest Guest { get; set; } = null!;

    public virtual Tvshow Show { get; set; } = null!;
}
