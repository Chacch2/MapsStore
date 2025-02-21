using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSInfo.Models.DTOs
{
    public class StoreTypeDto
    {
        public int TypeId { get; set; }

        public string Type { get; set; } = null!;

        public string? IconUrl { get; set; }
    }
}
