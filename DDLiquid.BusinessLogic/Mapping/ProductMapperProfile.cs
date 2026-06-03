using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.Domain.Entities.BaseProduct;
using DDLiquid.Domain.Entities.Consumable;
using DDLiquid.Domain.Entities.Liquid;
using DDLiquid.Domain.Entities.Product;
using DDLiquid.Domain.Entities.Vape;
using DDLiquid.Domain.Models.Product;

namespace DDLiquid.BusinessLogic.Mapping
{
    public class ProductMapperProfile : Profile
    {
                public ProductMapperProfile()
        {
            CreateMap<ProductData, ProductDTO>()
                .Include<LiquidData, LiquidDTO>()
                .Include<VapeData, VapeDTO>()
                .Include<ConsumableData, ConsumableDTO>()
                .ReverseMap();
            CreateMap<LiquidData, LiquidDTO>()
                .IncludeBase<ProductData, ProductDTO>()
                .ReverseMap();
            CreateMap<VapeData, VapeDTO>()
               .IncludeBase<ProductData, ProductDTO>()
               .ReverseMap();
            CreateMap<ConsumableData, ConsumableDTO>()
               .IncludeBase<ProductData, ProductDTO>()
               .ReverseMap();
            CreateMap<FlavorData, FlavorDTO>().ReverseMap();
            CreateMap<ProductImageData, ProductImageDTO>().ReverseMap();
        }
    }
}

