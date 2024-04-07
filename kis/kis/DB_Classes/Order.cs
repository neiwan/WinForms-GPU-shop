using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class Order
{
    public int OrderId { get; set; }

    public int? ShipmentId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public virtual ICollection<CardOrder> CardOrders { get; set; } = new List<CardOrder>();

    public virtual Shipment? Shipment { get; set; }
}
