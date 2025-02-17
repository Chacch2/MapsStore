using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TWSInfoDBContext _context;
        public IStoreRepository StoreRepository { get; }
        public IChainRepository ChainRepository { get; }

        public ITypeRepository TypeRepository { get; }

        public UnitOfWork(TWSInfoDBContext context)
        {
            _context = context;
            StoreRepository = new StoreRepository(_context);
            ChainRepository = new ChainRepository(_context);
            TypeRepository = new TypeRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
