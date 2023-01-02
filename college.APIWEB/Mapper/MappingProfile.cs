using System;
using AutoMapper;
using college.DTO;
using college.Models;

namespace college.APIWEB.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegisterDto, User>()
                .ForMember(dest => dest.UserName, o => o.MapFrom(src => src.Username));
            CreateMap<User, UserRegisterDto>()
               .ForMember(dest => dest.Username, o => o.MapFrom(src => src.UserName));


            CreateMap<CourseDto, Course>()
               .ForMember(dest => dest.Name, o => o.MapFrom(src => src.CourseName));
            CreateMap<Course, CourseDto>()
               .ForMember(dest => dest.CourseName, o => o.MapFrom(src => src.Name));
        }
        
    }
}