using System;
using System.Collections.Generic;
using System.Text;
using D_DLiquid.DataAccess.Reps;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.Domain.Models.Product;
using AutoMapper;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.BusinessLogic.Interfaces.Product;

namespace D_DStore.BusinessLogic.Services.BaseProduct
{
    public class LiquidServices : BaseService<LiquidData, LiquidDTO>, ILiquidService
    {
        public LiquidServices(IRepository<LiquidData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}