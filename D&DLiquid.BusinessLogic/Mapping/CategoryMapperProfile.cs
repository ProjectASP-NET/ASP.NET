using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DStore.Domain.Enums;
using D_DStore.Domain.Models;
namespace D_DStore.BusinessLogic.Mapping
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            CreateMap<ProductCategory, CategoryDTO>().ReverseMap();
        }
    }
}
