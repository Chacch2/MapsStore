using System;
using System.Collections.Generic;

namespace TWSInfo.EFModels;

public partial class Chains
{
    public int ChainId { get; set; }

    public string Name { get; set; } = null!;

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }

    public int TypeId { get; set; }

    public virtual ICollection<Stores> Stores { get; set; } = new List<Stores>();

    public virtual StoreTypes Type { get; set; } = null!;
}
