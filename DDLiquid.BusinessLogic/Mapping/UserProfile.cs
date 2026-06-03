using AutoMapper;
using DDLiquid.Domain.Entities.User;
using DDLiquid.Domain.Models.Auth;

namespace DDLiquid.BusinessLogic.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RoleData, RoleResponseData>();

            CreateMap<UserData, UserResponseData>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.NickName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.RegisteredOn, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}

