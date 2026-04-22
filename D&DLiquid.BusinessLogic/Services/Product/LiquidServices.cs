using System;
using System.Collections.Generic;
using System.Text;
using D_DLiquid.DataAccess.Reps;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.Domain.Models.Product;
using AutoMapper;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.BusinessLogic.Interfaces.Product;

namespace D_DStore.BusinessLogic.Services.BaseProduct
{
    public class LiquidServices : ILiquidService
    {
        private readonly IRepository<LiquidData> _repo;
        private readonly IMapper _mapper;

        public LiquidServices(IRepository<LiquidData> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LiquidDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<LiquidDTO>>(entities);
        }

        public async Task<LiquidDTO?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<LiquidDTO>(entity);
        }

        public async Task<LiquidDTO> CreateAsync(LiquidDTO dto)
        {
            var entity = _mapper.Map<LiquidData>(dto);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<LiquidDTO>(created);
        }

        public async Task<LiquidDTO?> UpdateAsync(int id, LiquidDTO dto)
        {
            var entity = _mapper.Map<LiquidData>(dto);
            var updated = await _repo.UpdateAsync(id, entity);
            return updated is null ? null : _mapper.Map<LiquidDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}