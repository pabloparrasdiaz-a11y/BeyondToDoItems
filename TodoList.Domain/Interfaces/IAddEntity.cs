
namespace TodoList.Domain.Interfaces
{
    public interface IAddEntity<TEntity>
    {
        void AddItem(TEntity entity);
    }
}
