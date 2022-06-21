using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApiBlazor.Shared
{
    public class Board
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ToDo> ToDos { get; set; }


        public Board(int id, string name)
        {
            Id = id;
            Name = name;
            ToDos = new List<ToDo>();
        }
        public Board(int id, string name, List<ToDo> _todos)
        {
            Id = id;
            Name = name;
            ToDos = _todos;
        }
        #endregion
    }
}
