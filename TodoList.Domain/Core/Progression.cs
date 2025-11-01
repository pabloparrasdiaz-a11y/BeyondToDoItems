
namespace TodoList.Domain.Core
{
    public class Progression: IEntity<Guid>
    {
        public int TodoItemId { get; set; }
        public DateTime Date { get; set; }
        public decimal Percent { get; set; }

        public Progression(int todoItemId, DateTime date, decimal percent)
        {
            TodoItemId = todoItemId;
            Date = date;
            Percent = percent;
        }
    }
}
