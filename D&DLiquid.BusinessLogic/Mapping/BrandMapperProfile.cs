using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AutoMapper;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Models.Product.Brand;

namespace D_DStore.BusinessLogic.Mapping
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<BrandData, BrandDTO>().ReverseMap();
        }
      
    }
}
