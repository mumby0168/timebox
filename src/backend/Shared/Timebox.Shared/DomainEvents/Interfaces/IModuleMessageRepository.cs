using System.Collections.Generic;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IModuleMessageRepository
    {
        void AddSubscriber<T>(string key, IDomainEventHandler<T> domainEventHandler) where T : IDomainEvent;
        
        IEnumerable<IMessageSubscription> GetSubscribers<T>(string key) where T : IDomainEvent;
    }
}