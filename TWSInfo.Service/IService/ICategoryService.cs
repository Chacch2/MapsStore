using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.DTOs;

namespace TWSInfo.Service.IService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoryTreeAsync();
    }
}
