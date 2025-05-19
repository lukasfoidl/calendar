using calendar_server.Enums;

namespace calendar_server.Models
{
    public class ToDo : IModel<ToDo>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Priority Priority { get; set; }

        public ToDo(string name, Priority priority)
        {
            Name = name;
            Priority = priority;
        }
    }
}

