using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DStore.Domain.Entities.User;
using D_DStore.Domain.Models.User;

namespace D_DStore.BusinessLogic.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile() {
        CreateMap<UserData,UserDTO>().ReverseMap();
        }
    }
}
