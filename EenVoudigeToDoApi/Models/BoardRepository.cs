using Microsoft.AspNetCore.Mvc;
namespace EenVoudigeToDoApi.Models
{    
    public class BoardRepository : IBoardRepository
    {
        private readonly Dictionary<int, Board> _data = new();
        public List<ToDo> toDos;
        public ToDo todo = new ToDo(6,"Werken",DateTime.Now.AddDays(-6),DateTime.Now.AddDays(-5), DateTime.Today.AddDays(100));

        public BoardRepository()
        {
            toDos = new List<ToDo>();
            toDos.Add(todo);
            _data.Add(1, new Board(1,"EersteBoard",toDos));
            _data.Add(2, new Board(2,"TweedeBoard"));
            _data.Add(3, new Board(3,"DerdeBoard"));
            _data.Add(4, new Board(4,"VierdeBoard"));
            _data.Add(5, new Board(5,"VijfdeBoard"));
        }
        public bool ExistsBoard(int id)
        {
            if (_data.ContainsKey(id))
                return true;
            else
                return false;
        }
        public IEnumerable<Board> GetAll()
        {
            return _data.Values;
        }
        public Board GetBoard(int id)
        {
            if (_data.ContainsKey(id))
                return _data[id];
            else
                throw new BoardException("Board does not exist");
        }
        public void AddBoard(Board board)
        {
            if (_data.ContainsKey(board.Id))
                _data.Add(board.Id, board);
            else
                throw new BoardException("Board already added");
        }
        public void RemoveBoard(Board board)
        {
            if (_data.ContainsKey(board.Id))
                _data.Remove(board.Id);
            else
                throw new BoardException("Board doesn't exist");
        }
        public void UpdateBoard(Board board)
        {
            if (_data.ContainsKey(board.Id)) _data[board.Id] = board;
            else
                throw new BoardException("Board doesn't exist");
        }
    }
}
