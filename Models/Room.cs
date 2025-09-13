using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Room
{
    public int Roomid { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public decimal? Area { get; set; }

    public string? Address { get; set; }

    public int Ownerid { get; set; }

    public int Statusid { get; set; }

    public DateTime? Createdat { get; set; }

    public int? Categoryid { get; set; }

    public int? Wardid { get; set; }

    public bool? Isvip { get; set; }

    public int? VipLevel { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual User Owner { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual RoomStatus Status { get; set; } = null!;

    public virtual Ward? Ward { get; set; }

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}
