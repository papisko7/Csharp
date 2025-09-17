using System.Collections.Generic;
using ToDoList.Domain.Model;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetToDos();
    }
}