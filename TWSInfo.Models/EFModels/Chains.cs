using System;
using System.Collections.Generic;

namespace TWSInfo.Models.EFModels;

public partial class Chains
{
    public int ChainId { get; set; }

    public string Name { get; set; } = null!;

    public string? LogoUrl { get; set; }

    public string? Description { get; set; }

    public int SubTypeId { get; set; }

    public virtual ICollection<Stores> Stores { get; set; } = new List<Stores>();

    public virtual SubTypes SubType { get; set; } = null!;
}
