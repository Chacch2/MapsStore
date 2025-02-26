using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.DTOs;
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

        public async Task<IEnumerable<Stores>> GetStoresByCategoriesAsync(string? mainCategory, string? subCategory, string? chainName)
        {
            var query = _context.Stores
                        .Include(s => s.Chain)
                        .ThenInclude(c => c.SubType)
                        .ThenInclude(st => st.StoreType)
                        .AsQueryable();

            if (!string.IsNullOrEmpty(mainCategory))
            {
                string mainLower = mainCategory.ToLower();
                query = query.Where(s => s.Chain != null &&
                                         s.Chain.SubType != null &&
                                         s.Chain.SubType.StoreType != null &&
                                         s.Chain.SubType.StoreType.Name.ToLower() == mainLower);
            }
            if (!string.IsNullOrEmpty(subCategory))
            {
                string subLower = subCategory.ToLower();
                query = query.Where(s => s.Chain != null &&
                                         s.Chain.SubType != null &&
                                         s.Chain.SubType.Name.ToLower() == subLower);
            }
            if (!string.IsNullOrEmpty(chainName))
            {
                string chainLower = chainName.ToLower();
                query = query.Where(s => s.Chain != null &&
                                         s.Chain.Name.ToLower().Contains(chainLower));
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
