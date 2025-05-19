using AutoMapper;
using calendar_server.Data;
using calendar_server.Dtos;
using calendar_server.Models;

namespace calendar_server.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo, ToDoDto>, IToDoRepository
    {
        public ToDoRepository(ApplicationDbContext context, IMapper mapper) : base(context, context.ToDos, mapper) { }
    }
}
