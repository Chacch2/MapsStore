using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;
using TWSInfo.Service.IService;

namespace TWSInfo.Service
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public async Task<IEnumerable<StoreTypes>> GetAllTypesAsync()
        {
            return await _unitOfWork.TypeRepository.GetAllAsync();
        }

        public async Task<StoreTypes> GetTypeByIdAsync(int id)
        {
            return await _unitOfWork.TypeRepository.GetByIdAsync(id);
        }
    }
}
