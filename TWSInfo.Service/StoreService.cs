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

        public StoreService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Stores>> GetAllStoresAsync()
        {
            return await _unitOfWork.StoreRepository.GetAllAsync();
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

        public async Task<IEnumerable<Stores>> GetStoresByChainIdAsync(int chainId)
        {
            return await _unitOfWork.StoreRepository.GetStoresByChainIdAsync(chainId);
        }

        public async Task<IEnumerable<Stores>> GetStoresByTypeIdAsync(int typeId)
        {
            return await _unitOfWork.StoreRepository.GetStoresByTypeIdAsync(typeId);
        }

        public async Task<IEnumerable<StoreDto>> GetAllStoresAsync(string? filterOn, string? filterQuery)
        {
            var stores = await _unitOfWork.StoreRepository.GetAllStoresAsync(filterOn, filterQuery);
            return _mapper.Map<IEnumerable<StoreDto>>(stores);
        }
    }
}
