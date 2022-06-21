using Microsoft.AspNetCore.Mvc;

namespace EenVoudigeToDoApi.Models
{    
    public class ToDoRepository : IToDoRepository
    {
        private readonly Dictionary<int, ToDo> _data = new();
        public ToDoRepository()
        {
            _data.Add(1, new ToDo(1, "Web4 Taak", DateTime.Today.AddDays(-7), DateTime.Today.AddDays(-5), DateTime.Today.AddDays(100)));
            _data.Add(2, new ToDo(2, "Training Voetbal", DateTime.Today.AddDays(-15), DateTime.Today.AddDays(-3), DateTime.Today.AddDays(100)));
            _data.Add(3, new ToDo(3, "Muziekles", DateTime.Today.AddDays(-12), DateTime.Today.AddDays(-2), DateTime.Today.AddDays(100)));
            _data.Add(4, new ToDo(4, "Presentatie", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-7), DateTime.Today.AddDays(100)));
            _data.Add(5, new ToDo(5, "Pauze", DateTime.Today.AddDays(-17), DateTime.Today.AddDays(-10), DateTime.Today.AddDays(100)));
        }
        public bool ExistsToDo(int id) 
        { 
            if (_data.ContainsKey(id)) 
                return true; 
            else 
                return false; }
        public IEnumerable<ToDo> GetAll()
        {
            return _data.Values;
        }
        public ToDo GetToDo(int id)
        {
            if (_data.ContainsKey(id))
                return _data[id];
            else
                throw new ToDoException("ToDo does not exist");
        }
        public void AddToDo(ToDo todoapi)
        {
            if (_data.ContainsKey(todoapi.Id))
                _data.Add(todoapi.Id, todoapi);
            else
                throw new ToDoException("ToDo already added");
        }
        public void RemoveToDo(ToDo todo)
        {
            if (_data.ContainsKey(todo.Id))
                _data.Remove(todo.Id);
            else
                throw new ToDoException("ToDo doesn't exist");
        }
        public void UpdateToDo(ToDo todo)
        {
            if (_data.ContainsKey(todo.Id)) _data[todo.Id] = todo;
            else
                throw new ToDoException("ToDo doesn't exist");
        }
    }
}
