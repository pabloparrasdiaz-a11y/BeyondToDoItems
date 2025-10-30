
namespace TodoItems.Domain.Abstractions
{
    public interface IProgressionRepository
    {
        void RegisterProgression(int id, DateTime dateTime, decimal percent);
    }
}
