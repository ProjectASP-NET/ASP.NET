using System;
using System.Collections.Generic;
using System.Text;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Interfaces
{
    public interface ILiquid
    {
        Task<IEnumerable<LiquidDTO>> GetAllAsync();
        Task<LiquidDTO?> GetByIdAsync(int id);
        Task<LiquidDTO> CreateAsync(LiquidDTO liquid);
        Task<LiquidDTO?> UpdateAsync(int id, LiquidDTO liquid);
        Task<bool> DeleteAsync(int id);
    }
}
