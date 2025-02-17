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
    public class ChainRepository : Repository<Chains>, IChainRepository
    {
        private readonly TWSInfoDBContext _context;

        public ChainRepository(TWSInfoDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chains>> GetChainsByTypeIdAsync(int typeId)
        {
            return await _context.Chains.Where(c => c.TypeId == typeId).ToListAsync();
        }

        public async Task<Chains> GetChainWithStoresAsync(int id)
        {
            return await _context.Chains.Include(c => c.Stores).FirstOrDefaultAsync(c => c.ChainId == id);
        }
    }
}
