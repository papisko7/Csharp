using System.Collections.Generic;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Model;
using ToDoList.Domain.ViewModels;

namespace ToDoList.Core.App.Services
{
    public class ToDoService : IToDoService
    {
        private IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public ToDoViewModel GetToDos()
        {
            return new ToDoViewModel 
            {
                ToDos = (IEnumerable<ToDo>)_toDoRepository.GetToDos()
            };
        }
    }
}