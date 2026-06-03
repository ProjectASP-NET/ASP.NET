using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Entities.Vape;
using DDLiquid.Domain.Models.Product;

namespace DDLiquid.BusinessLogic.Services.BaseProduct
{
    public class VapeServices : BaseService<VapeData, VapeDTO>, IVapeService 
    {
        public VapeServices(IRepository<VapeData> repo, IMapper mapper) : base(repo,mapper) { }
    }
}
        
