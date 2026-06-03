using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.Domain.Enums;
using DDLiquid.Domain.Models;
namespace DDLiquid.BusinessLogic.Mapping
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<ProductCategoryData, CategoryDTO>().ReverseMap();
        }
    }
}

