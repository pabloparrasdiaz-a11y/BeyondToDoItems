
namespace TodoList.Domain.Interfaces
{
    public interface IAddTodoItem
    {
        void AddItem(int id, string title, string description, string category);
    }
}
