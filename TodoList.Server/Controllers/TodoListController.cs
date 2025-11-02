using Microsoft.AspNetCore.Mvc;
using TodoList.Application.DTO;
using TodoList.Application.Interfaces;
using TodoList.Domain.Core;
using TodoList.Domain.Interfaces.Repositories;

namespace TodoList.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoList _todoList;
        private readonly ITodoListRepository _todoListRepository;
        public TodoListController(ITodoList todoList, ITodoListRepository todoListRepository)
        {
            _todoList = todoList;
            _todoListRepository = todoListRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            try
            {
                var result = _todoList.PrintItems();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(TodoItemUpdateDTO command)
        {
            try
            {
                _todoList.UpdateItem(command.Id, command.Description);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(TodoItemDTO command)
        {
            try
            {
                var index = _todoListRepository.GetNextId();
                _todoList.AddItem(index, command.Title, command.Description, command.Category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("progression")]
        public ActionResult AddProgression([FromBody] ProgressionDTO command)
        {
            try
            {
                _todoList.RegisterProgression(command.TodoItemId, command.Date, command.Percent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _todoList.RemoveItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete]
        //public ActionResult DeleteProgression(int todoItemId, string progressionId)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
