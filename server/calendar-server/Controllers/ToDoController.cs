using calendar_server.Dtos;
using calendar_server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace calendar_server.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public ToDoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoDto>> Get()
        {
            var toDos = await _repository.GetAllAsync();
            return toDos;
            
            //return Enumerable.Range(1, 5).Select(index => new ToDoDto
            //(
            //    index,
            //    "Test " + index,
            //    (Priority)Random.Shared.Next(0, 3)
            //));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddAsync(dto);
            return Ok();
        }
    }
}
