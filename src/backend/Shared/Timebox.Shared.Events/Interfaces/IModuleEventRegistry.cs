using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timebox.Modules.Events.Interfaces
{
    public interface IModuleEventRegistry
    {
        void AddSubscriber<T>(string key, Func<object, Task> action) where T : IDomainEvent;
        
        IEnumerable<IEventSubscription> GetSubscribers<T>(string key) where T : IDomainEvent;
    }
}