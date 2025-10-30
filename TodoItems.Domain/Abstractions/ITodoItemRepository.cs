using TodoItems.Domain.Models;

namespace TodoItems.Domain.Abstractions
{
    public interface ITodoItemRepository: IRepository<TodoItem, int>
    {
    }
}
