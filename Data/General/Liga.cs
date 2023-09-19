using System;
using System.Collections.Generic;

namespace Lab.Data.General;

public partial class Liga
{
    public int Id { get; set; }

    public string Emri { get; set; } = null!;

    public virtual ICollection<Ekipaa> Ekipaa { get; set; } = new List<Ekipaa>();
}
