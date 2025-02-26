using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Models.DTOs
{
    public class StoreDto
    {
        public int StoreId { get; set; }
        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public bool? IsOpen { get; set; }

        public string? Contact { get; set; }

    }
}
