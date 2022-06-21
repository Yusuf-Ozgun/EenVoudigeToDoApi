using EenVoudigeToDoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            this._repo = repo;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAll();
        }
        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUserById")]
        public User Get(int id)
        {
            return _repo.GetUser(id);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repo.ExistsUser(id))
            {
                return NotFound();
            }
            _repo.RemoveUser(_repo.GetUser(id));
            return NoContent();
        }
        // Add
        [HttpPost] 
        public ActionResult<User> Post([FromBody] User user) 
        {
            _repo.AddUser(user); 
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user); 
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }
            if (!_repo.ExistsUser(id))
            {
                _repo.AddUser(user);
                return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            }
            var userDb = _repo.GetUser(id); _repo.UpdateUser(user);
            return new NoContentResult();
        }
    }
}