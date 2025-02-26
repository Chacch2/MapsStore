using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.DTOs;
using TWSInfo.Service.IService;

namespace TWSInfo.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoryTreeAsync()
        {
            // 從 Repository 取得完整的 StoreTypes 資料
            var storeTypes = await _unitOfWork.CategoryRepository.GetCategoryTreeAsync();
            // 使用 AutoMapper 將領域模型轉換為 DTO
            return _mapper.Map<IEnumerable<CategoryDto>>(storeTypes);
        }
    }
}
