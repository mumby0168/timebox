using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IModuleMessageRepository
    {
        void AddSubscriber<T>(string key, Func<object, Task> action) where T : IDomainEvent;
        
        IEnumerable<IMessageSubscription> GetSubscribers<T>(string key) where T : IDomainEvent;
    }
}