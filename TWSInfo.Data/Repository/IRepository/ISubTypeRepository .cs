using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository.IRepository
{
    public interface ISubTypeRepository : IRepository<SubTypes>
    {
        Task<IEnumerable<SubTypes>> GetSubTypesByStoreTypeIdAsync(int storeTypeId);
    }
}
