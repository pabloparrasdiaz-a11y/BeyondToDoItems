
namespace TodoList.Domain.Interfaces
{
    public interface IAddProgression
    {
        void RegisterProgression(int id, DateTime dateTime, decimal percent);
    }
}
