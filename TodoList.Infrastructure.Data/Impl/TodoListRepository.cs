using Microsoft.Extensions.Caching.Memory;
using TodoList.Domain.Core;
using TodoList.Domain.Interfaces.Repositories;

namespace TodoList.Infrastructure.Data.Impl
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IMemoryCache _cache;
        private const string CacheKey = "TodoList";

        public TodoListRepository(IMemoryCache cache)
        {
            _cache = cache;

            if (!_cache.TryGetValue(CacheKey, out List<TodoItem>? elements))
            {
                elements = new List<TodoItem> {
                new TodoItem(1, "Primer todoItem", "Primer primer todoItem", "Work"),
                new TodoItem(2, "Segundo todoItem", "Descripción Segundo todoItem", "Work"),
                new TodoItem(3, "Tercer todoItem", "Descripción Tercer todoItem", "Work"),
                new TodoItem(4, "Cuarto todoItem", "Descripción Cuarto todoItem", "Work")
                };
                _cache.Set(CacheKey, elements);
            }
        }

        public void AddItem(int id, string title, string description, string category)
        {
            var todoList = PrintItems();
            todoList.Add(new TodoItem(id, title, description, category));
        }

        public List<string> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public int GetNextId()
        {
            var todoList = PrintItems();

            if(!todoList.Any())
                return 1;

            else return todoList.Max(x => x.Id) + 1;
        }

        public List<TodoItem> PrintItems()
        {
            if (!_cache.TryGetValue(CacheKey, out List<TodoItem>? elements))
            {
                elements = new List<TodoItem> {
                new TodoItem(1, "Primer todoItem", "Primer primer todoItem", "Work"),
                new TodoItem(2, "Segundo todoItem", "Descripción Segundo todoItem", "Work"),
                new TodoItem(3, "Tercer todoItem", "Descripción Tercer todoItem", "Work"),
                new TodoItem(4, "Cuarto todoItem", "Descripción Cuarto todoItem", "Work")
                };
                _cache.Set(CacheKey, elements);
            }

            return elements;
        }

        public void RegisterProgression(int id, DateTime dateTime, decimal percent)
        {
            var todoList = PrintItems();
            var entity = todoList.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                throw new KeyNotFoundException("No existe");

            entity.Progressions.Add(new Progression(id, dateTime, percent));
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
