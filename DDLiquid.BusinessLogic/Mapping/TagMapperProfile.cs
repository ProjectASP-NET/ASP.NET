using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.Domain.Enums;
using DDLiquid.Domain.Models;


namespace DDLiquid.BusinessLogic.Mapping
{
    public class TagMapperProfile : Profile
    {
        public TagMapperProfile() { 
        CreateMap<ProductTagData, TagDTO>().ReverseMap();
        }
    }
}

