using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class CardOrder
{
    public int? CardId { get; set; }

    public int? OrderId { get; set; }

    public int CardOrderId { get; set; }

    public virtual Card? Card { get; set; }

    public virtual Order? Order { get; set; }
}
