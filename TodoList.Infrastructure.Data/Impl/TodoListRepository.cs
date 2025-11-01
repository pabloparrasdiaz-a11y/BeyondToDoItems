using Microsoft.Extensions.Caching.Memory;
using TodoList.Domain.Core;
using TodoList.Domain.Interfaces.Repositories;

namespace TodoList.Infrastructure.Data.Impl
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly IMemoryCache _cache;
        private const string CacheKeyTodoItem = "TodoItem";
        private const string CacheKeyprogression = "Progression";

        public TodoListRepository(IMemoryCache cache)
        {
            _cache = cache;

            if (!_cache.TryGetValue(CacheKeyTodoItem, out List<TodoItem>? todoItems))
            {
                todoItems = new List<TodoItem> {
                new TodoItem(1, "Primer todoItem", "Primer primer todoItem", "Work"),
                new TodoItem(2, "Segundo todoItem", "Descripción Segundo todoItem", "Work"),
                new TodoItem(3, "Tercer todoItem", "Descripción Tercer todoItem", "Work"),
                new TodoItem(4, "Cuarto todoItem", "Descripción Cuarto todoItem", "Work")
                };
                _cache.Set(CacheKeyTodoItem, todoItems);
            }

            if (!_cache.TryGetValue(CacheKeyprogression, out List<Progression>? progressions))
            {
                progressions = new List<Progression> {
                new Progression(1, new DateTime(2025,5,24), 25),
                new Progression(1, new DateTime(2025,6,2), 65),
                new Progression(1, new DateTime(2025,6,8), 100),
                new Progression(2, new DateTime(2025,6,10), 15),
                new Progression(2, new DateTime(2025,6,19), 40)
                };
                _cache.Set(CacheKeyprogression, progressions);
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
            if (_cache.TryGetValue(CacheKeyTodoItem, out List<TodoItem>? elements))
            {
                if (_cache.TryGetValue(CacheKeyprogression, out List<Progression>? progresions))
                {
                    var selectTodoItemsIds = progresions.Select(x => x.TodoItemId).Distinct();

                    foreach (var todoItemId in selectTodoItemsIds)
                    {
                        var todoItem = elements.First(x => x.Id == todoItemId);

                        todoItem.Progressions = progresions.Where(y => y.TodoItemId == todoItemId).ToList();
                    }
                }


                return elements;
            }

            return new List<TodoItem>();
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
