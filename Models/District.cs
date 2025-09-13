using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class District
{
    public int Districtid { get; set; }

    public string Districtname { get; set; } = null!;

    public int? Provinceid { get; set; }

    public virtual Province? Province { get; set; }

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
