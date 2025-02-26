using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository.IRepository
{
    public interface IStoreTypeRepository : IRepository<StoreTypes>
    {
        // 若需要可以額外定義：取得包含子分類的 StoreType
        Task<StoreTypes?> GetStoreTypeWithSubTypesAsync(int id);
    }
}
