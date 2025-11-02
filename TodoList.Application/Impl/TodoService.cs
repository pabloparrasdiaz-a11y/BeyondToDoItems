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
            _todoListRepository.AddItem(id, title, description, category);
        }

        public List<TodoItem> PrintItems()
        {
            var items = _todoListRepository.PrintItems();
            return items;
        }

        public void UpdateItem(int id, string description)
        {
            _todoListRepository.UpdateItem(id, description);
        }

        public void RegisterProgression(int id, DateTime dateTime, decimal percent)
        {
            _todoListRepository.RegisterProgression(id, dateTime, percent);
        }

        public void RemoveItem(int id)
        {
            _todoListRepository.RemoveItem(id);
        }

        
    }
}
