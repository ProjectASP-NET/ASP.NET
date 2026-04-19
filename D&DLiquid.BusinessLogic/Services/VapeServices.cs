using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Services
{
    public class VapeServices : IVapeService
    {
        private readonly IRepository<VapeData> _repo;
        private readonly IMapper _mapper;
        public VapeServices(IRepository<VapeData> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VapeDTO>> GetAllAsync()
        {
            var entities = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<VapeDTO>>(entities);
        }
        public async Task<VapeDTO?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<VapeDTO>(entity);
        }

        public async Task<VapeDTO> CreateAsync(VapeDTO dto)
        {
            var entity = _mapper.Map<VapeData>(dto);
            var created = await _repo.CreateAsync(entity);
            return _mapper.Map<VapeDTO>(created);
        }
        public async Task<VapeDTO?> UpdateAsync(int id, VapeDTO dto)
        {
            var entity = _mapper.Map<VapeData>(dto);
            var updated = await _repo.UpdateAsync(id, entity);
            return updated is null ? null : _mapper.Map<VapeDTO>(updated);
        }
        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}