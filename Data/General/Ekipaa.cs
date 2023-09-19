using System;
using System.Collections.Generic;

namespace Lab.Data.General;

public partial class Ekipaa
{
    public int Id { get; set; }

    public string Emri { get; set; } = null!;

    public int LigaId { get; set; }

    public virtual Liga Liga { get; set; } = null!;
}
