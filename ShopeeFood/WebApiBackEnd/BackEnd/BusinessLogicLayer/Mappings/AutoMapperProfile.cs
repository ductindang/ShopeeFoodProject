using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using System;

namespace BusinessLogicLayer.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
