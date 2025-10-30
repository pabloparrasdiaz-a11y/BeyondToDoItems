
namespace TodoItems.Domain.Abstractions
{
    public interface IRepository<TEntity, TEntityId> where TEntity : IEntity<TEntityId> where TEntityId : notnull
    {
        TEntity GetById(TEntityId id);
        List<TEntity> PrintItems();
        void AddItem(TEntity entity);
        void UpdateItem(TEntity entity);
        void Delete(TEntity entity);
        void RemoveItem(TEntityId id);
    }
}
