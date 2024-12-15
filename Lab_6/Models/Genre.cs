using System;
using System.Collections.Generic;

namespace Lab_6.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Tvshow> Tvshows { get; set; } = new List<Tvshow>();
}
