using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Payment
{
    public int Paymentid { get; set; }

    public int Ownerid { get; set; }

    public int Roomid { get; set; }

    public decimal Amount { get; set; }

    public string Paymentmethod { get; set; } = null!;

    public string? Paymentstatus { get; set; }

    public DateTime? Paymentdate { get; set; }

    public virtual User Owner { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
