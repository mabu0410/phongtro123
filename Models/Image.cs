using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Image
{
    public int Imageid { get; set; }

    public int Roomid { get; set; }

    public string Imageurl { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
