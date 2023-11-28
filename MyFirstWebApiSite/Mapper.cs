using AutoMapper;
using Entities;
using DTO;

namespace MyFirstWebApiSite
{
    public class Mapper : Profile
    {
        public Mapper() 
        { 
             CreateMap<UsersTbl,UserDTO>().ReverseMap();

             CreateMap<ProductsTbl, ProductAndCategoryDTO>().
                ForMember(dest => dest.CategoryName, opt => opt.MapFrom( src => src.Category.CategoryName))
               .ReverseMap();

             CreateMap<CaegoriesTbl,CategoryDTO>().ReverseMap();

             CreateMap<OrdersTbl,OrderDTO>().
                ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
               .ReverseMap();

             CreateMap<OrderItemTbl, OrderItemDTO>().ReverseMap();




        }
    }
}
