using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Entities.Vape;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Services.BaseProduct
{
    public class VapeServices : BaseService<VapeData, VapeDTO>, IVapeService 
    {
        public VapeServices(IRepository<VapeData> repo, IMapper mapper) : base(repo,mapper) { }
    }
}
        