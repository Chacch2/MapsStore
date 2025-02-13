using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;
using TWSInfo.Service.IService;

namespace TWSInfo.Service
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}
