using System;
using System.Collections.Generic;

namespace TWSInfo.EFModels;

public partial class Stores
{
    public int StoreId { get; set; }

    public int? ChainId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public bool? IsOpen { get; set; }

    public string? Contact { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int TypeId { get; set; }

    public virtual Chains? Chain { get; set; }

    public virtual ICollection<Favorites> Favorites { get; set; } = new List<Favorites>();

    public virtual StoreTypes Type { get; set; } = null!;
}
