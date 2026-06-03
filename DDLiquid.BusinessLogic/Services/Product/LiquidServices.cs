using System;
using System.Collections.Generic;
using System.Text;
using DDLiquid.DataAccess.Reps;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.Domain.Models.Product;
using AutoMapper;
using DDLiquid.Domain.Entities.Liquid;
using DDLiquid.BusinessLogic.Interfaces.Product;

namespace DDLiquid.BusinessLogic.Services.BaseProduct
{
    public class LiquidServices : BaseService<LiquidData, LiquidDTO>, ILiquidService
    {
        public LiquidServices(IRepository<LiquidData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
