using ToDoApiBlazor.Shared;

namespace EenVoudigeToDoApi.Models
{
    //CRUD
    public interface IToDoRepository
    {
        void AddToDo(ToDo toDo);
        ToDo GetToDo(int id);
        IEnumerable<ToDo> GetAll();
        void RemoveToDo(ToDo toDo);
        void UpdateToDo(ToDo toDo);
        bool ExistsToDo(int id);
    }
}
