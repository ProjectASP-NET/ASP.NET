using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DStore.Domain.Entities.Consumable;
using D_DStore.Domain.Entities.Liquid;
using D_DStore.Domain.Entities.Product;
using D_DStore.Domain.Entities.Vape;
using D_DStore.Domain.Models.Product;

namespace D_DStore.BusinessLogic.Mapping
{
    public class MapperProfile : Profile
    {
                public MapperProfile()
        {
            CreateMap<ProductData, ProductDTO>().ReverseMap();
            CreateMap<LiquidData, LiquidDTO>()
                .IncludeBase<ProductData, ProductDTO>()
                .ReverseMap();
            CreateMap<VapeData, VapeDTO>()
               .IncludeBase<ProductData, ProductDTO>()
               .ReverseMap();
            CreateMap<ConsumableData, ConsumableDTO>()
               .IncludeBase<ProductData, ProductDTO>()
               .ReverseMap();
        }
    }
}
