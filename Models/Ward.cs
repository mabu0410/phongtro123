using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Ward
{
    public int Wardid { get; set; }

    public string Wardname { get; set; } = null!;

    public int? Districtid { get; set; }

    public virtual District? District { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
