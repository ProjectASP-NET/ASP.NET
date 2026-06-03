using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Entities.Consumable;
using DDLiquid.Domain.Models.Product;

namespace DDLiquid.BusinessLogic.Services.BaseProduct
{
    public class ConsumableServices : BaseService<ConsumableData, ConsumableDTO>, IConsumableService
    {
        public ConsumableServices(IRepository<ConsumableData> repo, IMapper mapper) : base(repo, mapper) { }
        
    }

}
