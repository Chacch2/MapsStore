using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSInfo.Models.DTOs
{
    public class ChainDto
    {
        public int ChainId { get; set; }

        public string Name { get; set; } = null!;

        public string? LogoUrl { get; set; }

        public string? Description { get; set; }
    }
}
