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
    public class StoreRepository : Repository<Stores>, IStoreRepository
    {
        private readonly TWSInfoDBContext _context;

        public StoreRepository(TWSInfoDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stores>> GetStoresByChainIdAsync(int chainId)
        {
            return await _context.Stores.Where(s => s.ChainId == chainId).ToListAsync();
        }

        public async Task<IEnumerable<Stores>> GetStoresByTypeIdAsync(int typeId)
        {
            return await _context.Stores.Where(s => s.TypeId == typeId).ToListAsync();
        }
    }
}
