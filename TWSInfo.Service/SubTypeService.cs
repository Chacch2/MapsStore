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
    public class SubTypeService : ISubTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubTypeDto>> GetAllSubTypesAsync()
        {
            var subTypes = await _unitOfWork.SubTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubTypeDto>>(subTypes);
        }

        public async Task<IEnumerable<SubTypeDto>> GetSubTypesByStoreTypeIdAsync(int storeTypeId)
        {
            var subTypes = await _unitOfWork.SubTypeRepository.GetSubTypesByStoreTypeIdAsync(storeTypeId);
            return _mapper.Map<IEnumerable<SubTypeDto>>(subTypes);
        }

        public async Task<SubTypeDto?> GetSubTypeByIdAsync(int id)
        {
            var subType = await _unitOfWork.SubTypeRepository.GetByIdAsync(id);
            return _mapper.Map<SubTypeDto>(subType);
        }

        public async Task AddSubTypeAsync(SubTypeDto subTypeDto)
        {
            var subType = _mapper.Map<SubTypes>(subTypeDto);
            await _unitOfWork.SubTypeRepository.AddAsync(subType);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateSubTypeAsync(SubTypeDto subTypeDto)
        {
            var subType = await _unitOfWork.SubTypeRepository.GetByIdAsync(subTypeDto.SubTypeId);
            if (subType != null)
            {
                _mapper.Map(subTypeDto, subType);
                _unitOfWork.SubTypeRepository.Update(subType);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteSubTypeAsync(int id)
        {
            var subType = await _unitOfWork.SubTypeRepository.GetByIdAsync(id);
            if (subType != null)
            {
                _unitOfWork.SubTypeRepository.Remove(subType);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
