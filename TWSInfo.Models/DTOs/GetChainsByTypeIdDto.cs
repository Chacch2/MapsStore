using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSInfo.Models.DTOs
{
    public class GetChainsByTypeIdDto
    {
        public int ChainId { get; set; }
        public string ChainName { get; set; }
        public string? ChainLogoUrl { get; set; }
    }
}
