using System.Threading.Tasks;

namespace Timebox.Modules.Events.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishDomainEventAsync<T>(T @event) where T : IDomainEvent;
    }
}