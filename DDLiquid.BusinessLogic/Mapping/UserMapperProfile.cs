using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DDLiquid.Domain.Entities.User;
using DDLiquid.Domain.Models.User;

namespace DDLiquid.BusinessLogic.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() {
        CreateMap<UserData,UserDTO>().ReverseMap();
        }
    }
}

