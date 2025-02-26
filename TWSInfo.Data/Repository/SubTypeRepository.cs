using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository
{
    public class SubTypeRepository : Repository<SubTypes>, ISubTypeRepository
    {
        private readonly TWSInfoDBContext _context;

        public SubTypeRepository(TWSInfoDBContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<SubTypes>> GetSubTypesByStoreTypeIdAsync(int storeTypeId)
        {
            return await _context.SubTypes
                .Where(st => st.StoreTypeId == storeTypeId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
