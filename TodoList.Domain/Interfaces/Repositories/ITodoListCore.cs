
namespace TodoList.Domain.Interfaces.Repositories
{
    public interface ITodoListCore : IAddTodoItem, IUpdateTodoItem, IRemoveTodoItem, IAddProgression, IPrintTodoItems
    {
    }
}
