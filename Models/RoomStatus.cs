using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class RoomStatus
{
    public int Statusid { get; set; }

    public string Statusname { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
