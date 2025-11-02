using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        private readonly ILogger<TodoListController> _logger;
        public TodoListController(ITodoList todoList, ITodoListRepository todoListRepository, ILogger<TodoListController> logger)
        {
            _todoList = todoList;
            _todoListRepository = todoListRepository;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            try
            {
                _logger.LogInformation("Get");
                var result = _todoList.PrintItems();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult Update(TodoItemUpdateDTO command)
        {
            try
            {
                _logger.LogInformation($"Update: {JsonSerializer.Serialize(command)}");
                _todoList.UpdateItem(command.Id, command.Description);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Create(TodoItemDTO command)
        {
            try
            {
                _logger.LogInformation($"Create: {JsonSerializer.Serialize(command)}");
                var index = _todoListRepository.GetNextId();
                _todoList.AddItem(index, command.Title, command.Description, command.Category);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Create: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("progression")]
        public ActionResult AddProgression([FromBody] ProgressionDTO command)
        {
            try
            {
                _logger.LogInformation($"AddProgression: {JsonSerializer.Serialize(command)}");
                _todoList.RegisterProgression(command.TodoItemId, command.Date, command.Percent);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddProgression: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Delete: {id}");
                _todoList.RemoveItem(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete: {ex.Message}");
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
