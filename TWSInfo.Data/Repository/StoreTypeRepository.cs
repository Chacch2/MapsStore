using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository
{
    public class StoreTypeRepository : Repository<StoreTypes>, IStoreTypeRepository
    {
        private readonly TWSInfoDBContext _context;
        public StoreTypeRepository(TWSInfoDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<StoreTypes?> GetStoreTypeWithSubTypesAsync(int id)
        {
            return await _context.StoreTypes
                .Include(st => st.SubTypes)
                .AsNoTracking()
                .FirstOrDefaultAsync(st => st.StoreTypeId == id);
        }
    }
}
