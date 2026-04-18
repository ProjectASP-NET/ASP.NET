using System;
using System.Collections.Generic;
using System.Text;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Interfaces
{
    public interface IVapeService
    {
        Task<IEnumerable<VapeDTO>> GetAllAsync();
        Task<VapeDTO?> GetByIdAsync(int id);
        Task<VapeDTO> CreateAsync(VapeDTO vape);
        Task<VapeDTO?> UpdateAsync(int id, VapeDTO vape);
        Task<bool> DeleteAsync(int id);
    }
}
