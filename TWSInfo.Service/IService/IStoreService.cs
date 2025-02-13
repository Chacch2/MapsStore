using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Service.IService
{
    public interface IStoreService
    {
        Task<IEnumerable<Stores>> GetAllStoresAsync();
        Task<Stores> GetStoreByIdAsync(int id);
        Task AddStoreAsync(Stores store);
        Task UpdateStoreAsync(Stores store);
        Task DeleteStoreAsync(int id);
    }
}
