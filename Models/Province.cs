using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Province
{
    public int Provinceid { get; set; }

    public string Provincename { get; set; } = null!;

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
