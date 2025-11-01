using TodoList.Application.Interfaces;
using TodoList.Domain.Core;
using TodoList.Domain.Interfaces.Repositories;

namespace TodoList.Application.Impl
{
    public class TodoService : ITodoList
    {
        private readonly ITodoListRepository _todoListRepository;
        public TodoService(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }
        public void AddItem(int id, string title, string description, string category)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> PrintItems()
        {
            throw new NotImplementedException();
        }

        public void RegisterProgression(int id, DateTime dateTime, decimal percent)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(int id, string description)
        {
            throw new NotImplementedException();
        }
    }
}
