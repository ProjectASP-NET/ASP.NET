using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product.Brand;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Models.Product.Brand;
namespace D_DStore.BusinessLogic.Services.Product.Brand
{
    public class BrandService : BaseService<BrandData, BrandDTO>, IBrandService
    {
        public BrandService(IRepository<BrandData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
