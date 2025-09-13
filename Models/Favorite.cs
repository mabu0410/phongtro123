using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Favorite
{
    public int Favoriteid { get; set; }

    public int Userid { get; set; }

    public int Roomid { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
