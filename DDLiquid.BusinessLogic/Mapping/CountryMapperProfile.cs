using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Models.Product.Brand;

namespace DDLiquid.BusinessLogic.Mapping
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CountryData, CountryDTO>().ReverseMap();
        }
    }
}

