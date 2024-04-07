using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class User
{
    public int UserId { get; set; }

    public List<string>? UserName { get; set; }

    public List<string>? UserCity { get; set; }

    public List<string>? UserAdres { get; set; }

    public List<string>? UserRole { get; set; }

    public List<string>? UserLogin { get; set; }

    public List<string>? UserPassword { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
