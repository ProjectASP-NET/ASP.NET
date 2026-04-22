using D_DStore.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.BusinessLogic.Interfaces
{
    public interface IBaseService<TDTO>
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO?> GetByIdAsync(int id);
        Task<TDTO> CreateAsync(TDTO liquid);
        Task<TDTO?> UpdateAsync(int id, TDTO liquid);
        Task<bool> DeleteAsync(int id);
    }
}
