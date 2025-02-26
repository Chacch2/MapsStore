using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSInfo.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IStoreRepository StoreRepository { get; }
        IChainRepository ChainRepository { get; }
        IStoreTypeRepository StoreTypeRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISubTypeRepository SubTypeRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
