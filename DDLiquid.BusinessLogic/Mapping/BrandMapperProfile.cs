using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AutoMapper;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Models.Product.Brand;

namespace DDLiquid.BusinessLogic.Mapping
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<BrandData, BrandDTO>().ReverseMap();
        }
      
    }
}

