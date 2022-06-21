using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{
    //CRUD
    public interface IToDoRepository
    {
        void AddToDo(ToDo country);
        ToDo GetToDo(int id);
        IEnumerable<ToDo> GetAll();
        void RemoveToDo(ToDo country);
        void UpdateToDo(ToDo country);
        bool ExistsToDo(int id);
    }
}
