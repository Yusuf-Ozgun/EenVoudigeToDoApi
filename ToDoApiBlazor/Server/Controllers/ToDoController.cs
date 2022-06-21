using EenVoudigeToDoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Helpers;
using ToDoApiBlazor.Shared;

namespace ToDoApiBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            this._repo = repo;
            foreach (var item in repo.GetAll())
            {
                if (item.VervalDatum.Date < DateTime.Today)
                {

                    // POST: Email
                    [HttpPost]
                    IActionResult SendEmail()
                    {
                        string useremail = User.ToString() + "@hotmail.com";
                        string subject = "Automatische mail vervaldatum.";
                        string body = "Uw todo is vervallen. Gelieve contact op te nemen met de systeembeheerder.";

                        WebMail.Send(useremail, subject, body, null, null, null, true, null, null, null, null, null, null);
                        ViewBag.msg = "email is succesvol verzonden!";
                        return View();
                    }
                    SendEmail();
                }
            }
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
                return CreatedAtAction(nameof(Get), new { id = toDo.Id }, toDo);
            }
            var toDoDb = _repo.GetToDo(id); _repo.UpdateToDo(toDo);
            return new NoContentResult();
        }
        //public async Task<IActionResult> GetToDos()
        //{
        //    return Ok(ToDos);
        //}

    }
}
