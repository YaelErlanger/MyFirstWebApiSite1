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
               

        } 
    }
}
