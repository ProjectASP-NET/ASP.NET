using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces;

namespace D_DStore.BusinessLogic.Services
{
    public abstract class BaseService<TEntity, TDTO> : IBaseService<TDTO>
        where TEntity : class
        where TDTO : class
    {
        protected readonly IRepository<TEntity> _repo;
        protected readonly IMapper _mapper;

        protected BaseService(IRepository<TEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>> GetAllAsync()
            => _mapper.Map<IEnumerable<TDTO>>(await _repo.GetAllAsync());

        public async Task<TDTO?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<TDTO>(entity);
        }

        public async Task<TDTO> CreateAsync(TDTO dto)
            => _mapper.Map<TDTO>(await _repo.CreateAsync(_mapper.Map<TEntity>(dto)));

        public async Task<TDTO?> UpdateAsync(int id, TDTO dto)
        {
            var updated = await _repo.UpdateAsync(id, _mapper.Map<TEntity>(dto));
            return updated is null ? null : _mapper.Map<TDTO>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}