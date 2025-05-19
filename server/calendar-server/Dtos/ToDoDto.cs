using calendar_server.Enums;
using System.ComponentModel.DataAnnotations;

namespace calendar_server.Dtos
{
    public class ToDoDto : IDto
    {
        public int Id { get; }

        [Required(ErrorMessage = "ToDo name is required.")]
        [StringLength(10, ErrorMessage = "ToDo name cannot be longer than 10 characters.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Priority is required.")]
        [Range(0, 2, ErrorMessage = "Priority must be between 0 and 2.")]
        public Priority Priority { get; set; }

        public ToDoDto(int id, string name, Priority priority)
        {
            Id = id;
            Name = name;
            Priority = priority;
        }
    }
}
