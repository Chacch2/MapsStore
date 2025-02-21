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

        public async Task<IEnumerable<Stores>> GetAllStoresAsync(string? filterOn, string? filterQuery)
        {
            var stores = _context.Stores.Include("Chain").Include("Type").AsQueryable();

            //filtering

            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("TypeId", StringComparison.OrdinalIgnoreCase))
                {
                    stores = stores.Where(s => s.TypeId.ToString().Contains(filterQuery));
                }
                //else if (filterOn.Equals("ChainId", StringComparison.OrdinalIgnoreCase))
                //{
                //    stores = stores.Where(s => s.ChainId.ToString().Contains(filterQuery));
                //}
                //else if (filterOn.Equals("StoreName", StringComparison.OrdinalIgnoreCase))
                //{
                //    stores = stores.Where(s => s.StoreName.Contains(filterQuery));
                //}
            }
            return await stores.ToListAsync();
        }
    }
}
