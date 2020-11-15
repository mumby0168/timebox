using System.Threading.Tasks;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IMessageBroker
    {
        Task PublishDomainEventAsync<T>(T @event) where T : IDomainEvent;
    }
}