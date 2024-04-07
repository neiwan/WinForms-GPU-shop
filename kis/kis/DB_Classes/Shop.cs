using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class Shop
{
    public int ShopId { get; set; }

    public List<string>? ShopCity { get; set; }

    public List<string>? ShopName { get; set; }

    public virtual ICollection<ShopCard> ShopCards { get; set; } = new List<ShopCard>();
}
