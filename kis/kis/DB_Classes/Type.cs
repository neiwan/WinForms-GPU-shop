using System;
using System.Collections.Generic;

namespace kis.DB_Classes;

public partial class Type
{
    public int TypeId { get; set; }

    public List<string>? TypeName { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
