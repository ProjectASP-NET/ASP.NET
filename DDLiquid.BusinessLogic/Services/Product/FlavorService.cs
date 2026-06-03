using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Entities.Liquid;
using DDLiquid.Domain.Models.Product;
using DDLiquid.DataAccess.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.BusinessLogic.Services.Product
{
    public class FlavorService : BaseService<FlavorData, FlavorDTO>, IFlavorService
    {
        public FlavorService(IRepository<FlavorData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}

