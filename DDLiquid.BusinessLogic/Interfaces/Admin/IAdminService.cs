using DDLiquid.Domain.Models.Admin;

namespace DDLiquid.BusinessLogic.Interfaces.Admin
{
    public interface IAdminService
    {
        Task<AdminStatsDTO> GetStatsAsync();
    }
}
