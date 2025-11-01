
namespace TodoList.Domain.Core
{
    public class IEntity<TEntityID>
    {
        public TEntityID Id { get; set; }
    }
}
