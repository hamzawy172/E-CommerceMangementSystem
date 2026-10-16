using AutoMapper;
using E_CommerceMangementSystem.Dtos.OrderDto;
using E_CommerceMangementSystem.Models;

namespace E_CommerceMangementSystem.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order , OrderDto>();
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
