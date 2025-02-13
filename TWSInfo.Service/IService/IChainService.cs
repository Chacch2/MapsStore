using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Service.IService
{
    public interface IChainService
    {
        Task<IEnumerable<Chains>> GetAllChainsAsync();
        Task<Chains> GetChainByIdAsync(int id);
        Task AddChainAsync(Chains chain);
        Task UpdateChainAsync(Chains chain);
        Task DeleteChainAsync(int id);
    }
}
