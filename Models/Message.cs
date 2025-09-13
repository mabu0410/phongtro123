using System;
using System.Collections.Generic;

namespace PhongTro123.Models;

public partial class Message
{
    public int Messageid { get; set; }

    public int Senderid { get; set; }

    public int Receiverid { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? Sentat { get; set; }

    public virtual User Receiver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
