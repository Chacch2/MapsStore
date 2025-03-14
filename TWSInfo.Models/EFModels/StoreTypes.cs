﻿using System;
using System.Collections.Generic;

namespace TWSInfo.Models.EFModels;

public partial class StoreTypes
{
    public int StoreTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? IconUrl { get; set; }

    public virtual ICollection<SubTypes> SubTypes { get; set; } = new List<SubTypes>();
}
