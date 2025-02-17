using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository.IRepository
{
    public interface IChainRepository : IRepository<Chains>
    {
        Task<Chains> GetChainWithStoresAsync(int id);
        Task<IEnumerable<Chains>> GetChainsByTypeIdAsync(int typeId);
    }
}
