using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using TodoList.Application.DTO;
using TodoList.Application.Impl;
using TodoList.Application.Interfaces;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Infrastructure.Data.Impl;
using TodoList.Server.Controllers;

namespace TodoList.Test
{
    public class TodoListTests
    {
        private readonly Mock<ILogger<TodoListController>> _loggerMock;
        private readonly Mock<ITodoList> _todoListMock;
        private readonly Mock<ITodoListRepository> _todoListRepositoryMock;

        public TodoListTests()
        {
            _loggerMock = new Mock<ILogger<TodoListController>>();
            _todoListMock = new Mock<ITodoList>(MockBehavior.Strict);
            _todoListRepositoryMock = new Mock<ITodoListRepository>();
        }


        [Fact]
        public void UpdateTodoItem_ShouldReturnOk_WhenTodoItemIsValid()
        {
            //Arrange
            var controller = new TodoListController(_todoListMock.Object, _todoListRepositoryMock.Object, _loggerMock.Object);
            var updateTodo = new TodoItemUpdateDTO { Id = 1, Description = "Update test" };

            _todoListMock.Setup(s => s.UpdateItem(It.IsAny<int>(), It.IsAny<string>())).Verifiable();

            //Act
            var result = controller.Update(updateTodo);

            // Assert 
            _todoListMock.Verify(s => s.UpdateItem(1, "Update test"), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateTodoItem_ShouldUpdateItemInMemoryCache()
        {
            // Arrange
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var repository = new TodoListRepository(memoryCache);
            var service = new TodoService(repository);
            var controller = new TodoListController(service, repository, _loggerMock.Object);

            var dto = new TodoItemUpdateDTO { Id = 1, Description = "Updated description" };

            // Act
            var result = controller.Update(dto);

            // Assert
            var ok = Assert.IsType<OkResult>(result);

            var updated = repository.PrintItems().First(x => x.Id == 1);
            Assert.Equal("Updated description", updated.Description);
        }

        [Fact]
        public void UpdateTodoItem_ShouldReturnBadRequest_WhenIdNotExist()
        {
            // Arrange
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var repository = new TodoListRepository(memoryCache);
            var service = new TodoService(repository);
            var controller = new TodoListController(service, repository, _loggerMock.Object);

            var dto = new TodoItemUpdateDTO { Id = 9, Description = "Updated description" };

            // Act
            var result = controller.Update(dto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Sequence contains no matching element", badRequest.Value);
        }

    }
}