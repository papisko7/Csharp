using System.Collections.Generic;
using ToDoList.Domain.Model;

namespace ToDoList.Domain.ViewModels
{
    public class ToDoViewModel
    {
        public IEnumerable<ToDo> ToDos { get; set; }
    }
}