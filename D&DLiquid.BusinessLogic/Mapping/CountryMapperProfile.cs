using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Models.Product.Brand;

namespace D_DStore.BusinessLogic.Mapping
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CountryData, CountryDTO>().ReverseMap();
        }
    }
}
