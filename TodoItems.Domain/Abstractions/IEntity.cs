
namespace TodoItems.Domain.Abstractions
{
    public class IEntity<TEntityId>
    {
        public TEntityId Id { get; set; }
        public string CreationUser { get; set; }
        public string? DeleteUser { get; set; }
        public string? UpdateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
