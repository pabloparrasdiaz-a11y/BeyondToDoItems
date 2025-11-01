
namespace TodoList.Domain.Core
{
    public class Progression: IEntity<string>
    {
        public int TodoItemId { get; set; }
        public DateTime Date { get; set; }
        public decimal Percent { get; set; }

        public Progression(int todoItemId, DateTime date, decimal percent)
        {
            Id = Guid.NewGuid().ToString();
            TodoItemId = todoItemId;
            Date = date;
            Percent = percent;
        }
    }
}
