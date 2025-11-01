using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Interfaces;
using TodoList.Domain.Core;

namespace TodoList.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoList _todoList;
        public TodoListController(ITodoList todoList)
        {
            _todoList = todoList;
        }


        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            var result = _todoList.PrintItems();
            return Ok(result);
        }


    }
}
