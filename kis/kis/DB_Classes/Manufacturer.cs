using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public List<string>? ManufacturerName { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
