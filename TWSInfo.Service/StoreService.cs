using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.DTOs;
using TWSInfo.Models.EFModels;
using TWSInfo.Service.IService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TWSInfo.Service
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StoreDto>> GetAllStoresAsync(string? tag, double lat, double lon, int? storeId)
        {
            // 若 tag 為 null 或 _all，直接取得全部店家
            if (string.IsNullOrWhiteSpace(tag) || tag.Equals("_all", StringComparison.OrdinalIgnoreCase))
            {
                var allStores = await _unitOfWork.StoreRepository.GetAllAsync();
                if (storeId.HasValue)
                {
                    allStores = allStores.Where(s => s.StoreId == storeId.Value);
                }
                return _mapper.Map<IEnumerable<StoreDto>>(allStores);
            }

            // 移除前導底線，並根據底線分解字串
            var cleanedTag = tag.TrimStart('_'); // 例如 "food_cafe_staba"
            var parts = cleanedTag.Split('_', StringSplitOptions.RemoveEmptyEntries);

            string? mainCategory = parts.Length >= 1 ? parts[0] : null;
            string? subCategory = parts.Length >= 2 ? parts[1] : null;
            string? chainName = parts.Length >= 3 ? parts[2] : null;

            var stores = await _unitOfWork.StoreRepository.GetStoresByCategoriesAsync(mainCategory, subCategory, chainName);
            if (storeId.HasValue)
            {
                stores = stores.Where(s => s.StoreId == storeId.Value);
            }
            return _mapper.Map<IEnumerable<StoreDto>>(stores);

        }

        public async Task<Stores> GetStoreByIdAsync(int id)
        {
            return await _unitOfWork.StoreRepository.GetByIdAsync(id);
        }

        public async Task AddStoreAsync(Stores store)
        {
            await _unitOfWork.StoreRepository.AddAsync(store);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStoreAsync(Stores store)
        {
            _unitOfWork.StoreRepository.Update(store);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteStoreAsync(int id)
        {
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(id);
            if (store != null)
            {
                _unitOfWork.StoreRepository.Remove(store);
                await _unitOfWork.SaveChangesAsync();
            }
        }

    }
}
