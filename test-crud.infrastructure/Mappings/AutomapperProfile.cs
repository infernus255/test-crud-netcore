using AutoMapper;
using test_crud.core.DTOs;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
