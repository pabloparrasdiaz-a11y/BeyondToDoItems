
namespace TodoList.Domain.Interfaces.Repositories
{
    public interface ITodoListRepository: IAddTodoItem, IUpdateTodoItem, IRemoveTodoItem, IPrintTodoItems, IAddProgression
    {
        int GetNextId();
        List<string> GetAllCategories();
    }
}
