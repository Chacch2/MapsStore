using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.DTOs;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TWSInfoDBContext _context;

        public CategoryRepository(TWSInfoDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StoreTypes>> GetCategoryTreeAsync()
        {
            // 取得所有 StoreTypes，包含子分類與連鎖商家
            return await _context.StoreTypes
                .Include(st => st.SubTypes)
                    .ThenInclude(sub => sub.Chains)
                        .ThenInclude(chain => chain.Stores)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}
