using AutoMapper;
using D_DStore.Domain.Entities.User;
using D_DStore.Domain.Models.Auth;

namespace D_DStore.BusinessLogic.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserData, UserResponseData>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.NickName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.RegisteredOn, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
