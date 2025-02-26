using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.DTOs;

namespace TWSInfo.Service.IService
{
    public interface IStoreTypeService
    {
        Task<IEnumerable<StoreTypeDto>> GetAllStoreTypesAsync();
        Task<StoreTypeDto?> GetStoreTypeByIdAsync(int id);
        Task AddStoreTypeAsync(StoreTypeDto storeTypeDto);
        Task UpdateStoreTypeAsync(StoreTypeDto storeTypeDto);
        Task DeleteStoreTypeAsync(int id);
    }
}
