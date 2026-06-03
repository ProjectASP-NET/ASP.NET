using AutoMapper;
using DDLiquid.Domain.Entities.Order;
using DDLiquid.Domain.Models.Order;

namespace DDLiquid.BusinessLogic.Mapping
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<OrderData, OrderDTO>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ReverseMap();
            CreateMap<OrderItemData, OrderItemDTO>().ReverseMap();
        }
    }
}
