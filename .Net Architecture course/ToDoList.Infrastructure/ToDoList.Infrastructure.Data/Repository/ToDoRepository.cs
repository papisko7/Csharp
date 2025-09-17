using System.Collections.Generic;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Model;
using ToDoList.Infrastructure.Data.Context;

namespace ToDoList.Infrastructure.Data.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        public ToDoContext _toDoContext;
        
        public ToDoRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public IEnumerable<ToDo> GetToDos() 
        { 
            return _toDoContext.ToDos;
        }
    }
}