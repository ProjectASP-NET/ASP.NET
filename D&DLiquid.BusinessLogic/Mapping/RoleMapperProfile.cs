using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using D_DStore.Domain.Entities.User;
using D_DStore.Domain.Models.User;

namespace D_DStore.BusinessLogic.Mapping
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile() {
            CreateMap<RoleData, RoleDTO>().ReverseMap();
        }
    }
}
