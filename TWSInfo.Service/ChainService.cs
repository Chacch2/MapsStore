using Microsoft.EntityFrameworkCore;
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

namespace TWSInfo.Service
{
    public class ChainService : IChainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddChainAsync(Chains chain)
        {
            await _unitOfWork.ChainRepository.AddAsync(chain);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteChainAsync(int id)
        {
            var chain = await _unitOfWork.ChainRepository.GetByIdAsync(id);
            if (chain != null)
            {
                _unitOfWork.ChainRepository.Remove(chain);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Chains>> GetAllChainsAsync()
        {
            return await _unitOfWork.ChainRepository.GetAllAsync();
        }

        public async Task<Chains> GetChainByIdAsync(int id)
        {
            return await _unitOfWork.ChainRepository.GetByIdAsync(id);
        }


        public async Task UpdateChainAsync(Chains chain)
        {
            _unitOfWork.ChainRepository.Update(chain);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetChainsByTypeIdDto>> GetChainsByTypeIdAsync(int typeId)
        {
            // 從 Repository 取得 Chain 實體
            var chains = await _unitOfWork.ChainRepository.GetChainsByTypeIdAsync(typeId);

            // 將實體轉換成 DTO
            var dto = chains.Select(c => new GetChainsByTypeIdDto
            {
                ChainId = c.ChainId,
                ChainName = c.Name
            });

            return dto;
        }
    }
}
