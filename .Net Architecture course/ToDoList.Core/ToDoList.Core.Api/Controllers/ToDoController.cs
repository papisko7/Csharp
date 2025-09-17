using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.ViewModels;

namespace ToDoList.Core.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ToDoViewModel Index() 
        {
            return _toDoService.GetToDos();
        }
    }
}
