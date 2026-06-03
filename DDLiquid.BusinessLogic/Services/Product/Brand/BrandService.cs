using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product.Brand;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Models.Product.Brand;
namespace DDLiquid.BusinessLogic.Services.Product.Brand
{
    public class BrandService : BaseService<BrandData, BrandDTO>, IBrandService
    {
        public BrandService(IRepository<BrandData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}

