using ToDoList.Domain.ViewModels;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoService
    {
        public ToDoViewModel GetToDos();
    }
}