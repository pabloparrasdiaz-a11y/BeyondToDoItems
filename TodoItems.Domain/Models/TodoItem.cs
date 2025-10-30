using TodoItems.Domain.Abstractions;

namespace TodoItems.Domain.Models
{
    public class TodoItem: IEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<Progression> Progressions { get; set; }
        public bool IsCompleted { get => Progressions.Where(y => string.IsNullOrEmpty(y.DeleteUser)).Sum(x => x.Percent) >= 100; }

        public TodoItem(int id, string title, string category)
        {
            Id = id;
            Title = title;
            Description = category;
            CreationUser = "System";
            CreateDate = DateTime.Now;
            Progressions = new List<Progression>();
        }

        public void AddProgression(decimal percent, DateTime date)
        {
            if (Progressions.Where(y => string.IsNullOrEmpty(y.DeleteUser)).Sum(x => x.Percent) + percent > 100)
                throw new Exception("No puede superar el 100%");

            if(Progressions.Any() && Progressions.OrderByDescending(y => y.Date).First().Date > date)
                throw new Exception("No puede tener una fecha inferior a la última progresión");

            Progressions.Add(new Progression(Id, percent, date));
        }
    }
}
