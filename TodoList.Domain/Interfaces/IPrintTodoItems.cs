
using TodoList.Domain.Core;

namespace TodoList.Domain.Interfaces
{
    public interface IPrintTodoItems
    {
        List<TodoItem> PrintItems();
    }
}
