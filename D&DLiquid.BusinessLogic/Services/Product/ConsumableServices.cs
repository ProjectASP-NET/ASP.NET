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
    public class ConsumableServices : BaseService<ConsumableData, ConsumableDTO>, IConsumableService
    {
        public ConsumableServices(IRepository<ConsumableData> repo, IMapper mapper) : base(repo, mapper) { }
        
    }

}