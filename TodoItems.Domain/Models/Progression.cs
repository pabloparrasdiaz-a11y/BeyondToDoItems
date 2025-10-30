using TodoItems.Domain.Abstractions;

namespace TodoItems.Domain.Models
{
    public class Progression: IEntity<int>
    {
        public DateTime Date { get; set; }
        public decimal Percent { get; set; }
        public int TodoItemId { get; set; }

        public Progression(int todoItemId, decimal percent, DateTime date)
        {
            if (percent < 0 || percent > 100)
                throw new Exception("Porcentaje entre 0 y 100");

            TodoItemId = todoItemId;
            Percent = percent;
            Date = date;
        }
    }
}
