﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSInfo.Models.DTOs
{
    public class StoreTypeDto
    {
        public int StoreTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }
    }
}
