using System;
using System.Collections.Generic;

namespace TWSInfo.Models.EFModels;

public partial class SubTypes
{
    public int SubTypeId { get; set; }

    public int StoreTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? IconUrl { get; set; }

    public virtual ICollection<Chains> Chains { get; set; } = new List<Chains>();

    public virtual StoreTypes StoreType { get; set; } = null!;
}
