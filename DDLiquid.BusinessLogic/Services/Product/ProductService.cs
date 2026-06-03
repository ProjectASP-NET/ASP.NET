using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Entities.Product;
using DDLiquid.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.BusinessLogic.Services.Product
{
    public class ProductService : BaseService<ProductData, ProductDTO>, IProductService
    {
        public ProductService(IRepository<ProductData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}

