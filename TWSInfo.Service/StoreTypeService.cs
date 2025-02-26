using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.DTOs;
using TWSInfo.Models.EFModels;
using TWSInfo.Service.IService;

namespace TWSInfo.Service
{
    public class StoreTypeService : IStoreTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoreTypeDto>> GetAllStoreTypesAsync()
        {
            var storeTypes = await _unitOfWork.StoreTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StoreTypeDto>>(storeTypes);
        }

        public async Task<StoreTypeDto?> GetStoreTypeByIdAsync(int id)
        {
            var storeType = await _unitOfWork.StoreTypeRepository.GetByIdAsync(id);
            return _mapper.Map<StoreTypeDto>(storeType);
        }

        public async Task AddStoreTypeAsync(StoreTypeDto storeTypeDto)
        {
            var storeType = _mapper.Map<StoreTypes>(storeTypeDto);
            await _unitOfWork.StoreTypeRepository.AddAsync(storeType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStoreTypeAsync(StoreTypeDto storeTypeDto)
        {
            var storeType = await _unitOfWork.StoreTypeRepository.GetByIdAsync(storeTypeDto.StoreTypeId);
            if (storeType != null)
            {
                // 將 DTO 值複製到實體中
                _mapper.Map(storeTypeDto, storeType);
                _unitOfWork.StoreTypeRepository.Update(storeType);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteStoreTypeAsync(int id)
        {
            var storeType = await _unitOfWork.StoreTypeRepository.GetByIdAsync(id);
            if (storeType != null)
            {
                _unitOfWork.StoreTypeRepository.Remove(storeType);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
