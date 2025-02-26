using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.DTOs;

namespace TWSInfo.Service.IService
{
    public interface ISubTypeService
    {
        Task<IEnumerable<SubTypeDto>> GetAllSubTypesAsync();
        Task<IEnumerable<SubTypeDto>> GetSubTypesByStoreTypeIdAsync(int storeTypeId);
        Task<SubTypeDto?> GetSubTypeByIdAsync(int id);
        Task AddSubTypeAsync(SubTypeDto subTypeDto);
        Task UpdateSubTypeAsync(SubTypeDto subTypeDto);
        Task DeleteSubTypeAsync(int id);
    }
}
