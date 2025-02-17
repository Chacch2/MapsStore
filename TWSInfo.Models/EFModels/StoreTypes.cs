using System;
using System.Collections.Generic;

namespace TWSInfo.Models.EFModels;

public partial class StoreTypes
{
    public int TypeId { get; set; }

    public string Type { get; set; } = null!;

    public string? IconUrl { get; set; }

    public virtual ICollection<Chains> Chains { get; set; } = new List<Chains>();

    public virtual ICollection<Stores> Stores { get; set; } = new List<Stores>();
}
