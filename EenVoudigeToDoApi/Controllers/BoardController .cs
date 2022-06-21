using EenVoudigeToDoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private IBoardRepository _repo;

        public BoardController(IBoardRepository repo)
        {
            this._repo = repo;
        }
        // GET: api/Board
        [HttpGet]
        public IEnumerable<Board> Get()
        {
            return _repo.GetAll();
        }
        // GET: api/Board/5
        [HttpGet("{id}", Name = "GetBoardById")]
        public Board Get(int id)
        {
            return _repo.GetBoard(id);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_repo.ExistsBoard(id))
            {
                return NotFound();
            }
            _repo.RemoveBoard(_repo.GetBoard(id));
            return NoContent();
        }
        // Add
        [HttpPost] 
        public ActionResult<Board> Post([FromBody] Board board) 
        {
            _repo.AddBoard(board); 
            return CreatedAtAction(nameof(Get), new { id = board.Id }, board); 
        }

        // Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Board board)
        {
            if (board == null || board.Id != id)
            {
                return BadRequest();
            }
            if (!_repo.ExistsBoard(id))
            {
                _repo.AddBoard(board);
                return CreatedAtAction(nameof(Get), new { id = board.Id }, board);
            }
            var boardDb = _repo.GetBoard(id); _repo.UpdateBoard(board);
            return new NoContentResult();
        }
    }
}
