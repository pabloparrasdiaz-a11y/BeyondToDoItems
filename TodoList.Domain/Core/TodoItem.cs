
namespace TodoList.Domain.Core
{
    public class TodoItem: IEntity<int>
    {
        private List<string> _categories = new List<string> { "Work" };

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public List<Progression> Progressions { get; set; } = new List<Progression>();
        public bool IsCompleted { get => Progressions.Any() && Progressions.OrderByDescending(x => x.Date).First().Percent >= 100; }
        public decimal TotalPercent { get => Progressions.Sum(x => x.Percent); }

        public TodoItem(int index, string title, string description, string category)
        {
            if(string.IsNullOrWhiteSpace(title)) 
                title = "Sin título";

            if (string.IsNullOrWhiteSpace(category))
                title = "Work";

            else if (!_categories.Any(c => c == category))
                throw new Exception("La categoría no existe");

            Id = index;
            Title = title;
            Description = description;
            Category = category;
            Progressions = new List<Progression>();
        }

        public decimal Progression(decimal percent, DateTime date)
        {
            if(percent < 0 || percent > 100)
                throw new Exception("El porcentaje debe estar entre 0 y 100");

            if (Progressions.Any()){
                if (Progressions.OrderByDescending(x => x.Date).First().Date > date)
                    throw new Exception($"La fecha no puede ser anterior a la última progresión {Progressions.OrderByDescending(x => x.Date).First().Date.ToString("dd/MM/yyyy")}");

                if (Progressions.OrderByDescending(x => x.Date).First().Percent + percent > 100)
                    throw new Exception("El total de las progresiones no pueden superar el 100%");

                return Progressions.OrderByDescending(x => x.Date).First().Percent + percent;
            }
            

            return  percent;
        }

        public bool Remove()
        {
            if (Progressions.Any() && Progressions.Sum(x => x.Percent) > 50)
                throw new Exception("No es posible eliminar, progresión a mas del 50%");

            return true;
        }
    }
}
