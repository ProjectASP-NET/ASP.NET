using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Enums;
using DDLiquid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.BusinessLogic.Services.Product
{
    public class TagService : BaseService<ProductTagData,TagDTO> , ITagService
    {
        public TagService(IRepository<ProductTagData> repo , IMapper mapper) : base(repo , mapper) { }
    }
}

