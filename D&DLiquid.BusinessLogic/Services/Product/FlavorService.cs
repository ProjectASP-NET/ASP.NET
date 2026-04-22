using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Models.Product;
using D_DLiquid.DataAccess.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.BusinessLogic.Services.Product
{
    public class FlavorService : BaseService<FlavorData, FlavorDTO>, IFlavorService
    {
        public FlavorService(IRepository<FlavorData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
