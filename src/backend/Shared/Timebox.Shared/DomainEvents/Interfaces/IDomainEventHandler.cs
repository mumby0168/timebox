using System.Threading.Tasks;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task HandleAsync(object domainEvent);
    }
}