using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSInfo.Models.DTOs
{
    public class CategoryDto
    {
        // 這裡的 Id 可以是 StoreTypeId, SubTypeId 或 ChainId，視層級而定
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? IconUrl { get; set; }

        // 子節點：StoreType 的子節點是 SubTypes，SubType 的子節點是 Chains
        public List<CategoryDto> Children { get; set; } = new List<CategoryDto>();
    }
}
