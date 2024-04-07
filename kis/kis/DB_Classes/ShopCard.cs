using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class ShopCard
{
    public int? CardId { get; set; }

    public int? ShopId { get; set; }

    public int CardShopId { get; set; }

    public virtual Card? Card { get; set; }

    public virtual Shop? Shop { get; set; }
}
