using System;
using System.Collections.Generic;
using System.Text;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Interfaces
{
    public interface IConsumable
    {
        Task<IEnumerable<ConsumableDTO>> GetAllAsync();
        Task<ConsumableDTO?> GetByIdAsync(int id);
        Task<ConsumableDTO> CreateAsync(ConsumableDTO consumable);
        Task<ConsumableDTO?> UpdateAsync(int id, ConsumableDTO consumable);
        Task<bool> DeleteAsync(int id);
    }
}
