using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class Shipment
{
    public int ShipmentId { get; set; }

    public int? UserId { get; set; }

    public DateOnly? ShipmentDate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User? User { get; set; }
}
