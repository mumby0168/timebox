using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Modules.Events
{
    public class ModuleEventRegistry : IModuleEventRegistry
    {
        private readonly Dictionary<string, List<IEventSubscription>> _dictionary;

        public ModuleEventRegistry()
        {
            _dictionary = new Dictionary<string, List<IEventSubscription>>();
        }
        
        public void AddSubscriber<T>(string key, Func<object, Task> action) where T : IDomainEvent
        {
            var subscription = EventSubscription.Create<T>(action);
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key].Add(subscription);
            }
            else
            {
                var subscribers = new List<IEventSubscription> {subscription};
                _dictionary.Add(key, subscribers);
            }
        }

        public IEnumerable<IEventSubscription> GetSubscribers<T>(string key) where T : IDomainEvent
        {
            if (_dictionary.ContainsKey(key))
            {
                var subscribers = _dictionary[key];
                return subscribers;
            }

            return null;
        }
    }
}