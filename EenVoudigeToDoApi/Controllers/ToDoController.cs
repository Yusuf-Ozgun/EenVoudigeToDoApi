using EenVoudigeToDoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            this._repo = repo;
        }
        // GET: api/ToDo
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return _repo.GetAll();
        }
        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public ToDo Get(int id)
        {
            return _repo.GetToDo(id);
        }
        // Delete
        [HttpDelete("{id}")] 
        public IActionResult Delete(int id) 
        { 
            if (!_repo.ExistsToDo(id)) 
            { 
                return NotFound(); 
            } 
            _repo.RemoveToDo(_repo.GetToDo(id)); 
            return NoContent(); 
        }
        // Add
        [HttpPost]
        public ActionResult<ToDo> Post([FromBody] ToDo toDo)
        {
            _repo.AddToDo(toDo);
            return CreatedAtAction(nameof(Get), new { id = toDo.Id }, toDo);
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDo toDo)
        {
            if (toDo == null || toDo.Id != id) 
            { 
                return BadRequest(); 
            }
            if (!_repo.ExistsToDo(id)) 
            { 
                _repo.AddToDo(toDo); 
                return CreatedAtAction(nameof(Get), new { id = toDo.Id }, toDo); }
            var toDoDb = _repo.GetToDo(id); _repo.UpdateToDo(toDo); 
            return new NoContentResult();
        }
    }
}
