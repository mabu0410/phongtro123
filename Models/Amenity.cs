using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Amenity
{
    public int Amenityid { get; set; }

    public string Amenityname { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
