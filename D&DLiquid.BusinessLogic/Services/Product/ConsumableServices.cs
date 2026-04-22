using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Entities.Consumable;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Services.BaseProduct
{
    public class ConsumableServices : IConsumableService
    {
        private readonly IRepository<ConsumableData> _repo;
        private readonly IMapper _mapper;

        public ConsumableServices(IRepository<ConsumableData> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsumableDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ConsumableDTO>>(entities);
        }

        public async Task<ConsumableDTO?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<ConsumableDTO>(entity);
        }

        public async Task<ConsumableDTO> CreateAsync(ConsumableDTO dto)
        {
            var entity = _mapper.Map<ConsumableData>(dto);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<ConsumableDTO>(created);
        }

        public async Task<ConsumableDTO?> UpdateAsync(int id, ConsumableDTO dto)
        {
            var entity = _mapper.Map<ConsumableData>(dto);
            var updated = await _repo.UpdateAsync(id, entity);
            return updated is null ? null : _mapper.Map<ConsumableDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}
