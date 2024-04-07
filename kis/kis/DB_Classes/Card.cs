using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class Card
{
    public int CardId { get; set; }

    public int CategoryId { get; set; }

    public int? TypeId { get; set; }

    public List<string>? CardGpuName { get; set; }

    public int? Gpu { get; set; }

    public int? Ram { get; set; }

    public int? CoolerNum { get; set; }

    public int? CardPrice { get; set; }

    public int? CardNum { get; set; }

    public virtual ICollection<CardOrder> CardOrders { get; set; } = new List<CardOrder>();

    public virtual Manufacturer Category { get; set; } = null!;

    public virtual ICollection<ShopCard> ShopCards { get; set; } = new List<ShopCard>();

    public virtual Type? Type { get; set; }
}
