using System.Threading.Tasks;

namespace Timebox.Modules.Events.Interfaces
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(T domainEvent);
    }
}