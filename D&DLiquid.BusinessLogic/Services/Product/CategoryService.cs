using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Enums;
using D_DStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.BusinessLogic.Services.Product
{
    public class CategoryService : BaseService<ProductCategory, CategoryDTO>, ICategoryService
    {
        public CategoryService(IRepository<ProductCategory> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
