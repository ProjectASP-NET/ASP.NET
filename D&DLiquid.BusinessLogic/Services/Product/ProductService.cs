using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.BusinessLogic.Services.Product
{
    public class ProductService : BaseService<ProductData, ProductDTO>, IProductService
    {
        public ProductService(IRepository<ProductData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
