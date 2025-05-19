using AutoMapper;
using calendar_server.Dtos;
using calendar_server.Models;

namespace calendar_server.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDo, ToDoDto>().ReverseMap();
        }
    }
}
