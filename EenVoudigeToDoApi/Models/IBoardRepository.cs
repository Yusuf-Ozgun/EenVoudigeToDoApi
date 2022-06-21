using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{
    //CRUD
    public interface IBoardRepository
    {
        void AddBoard(Board board);
        Board GetBoard(int id);
        IEnumerable<Board> GetAll();
        void RemoveBoard(Board board);
        void UpdateBoard(Board board);
        bool ExistsBoard(int id);

    }
}
