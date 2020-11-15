using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public class ModuleMessageRepository : IModuleMessageRepository
    {
        private readonly ILogger<ModuleMessageRepository> _logger;
        private Dictionary<string, List<IMessageSubscription>> _dictionary;

        public ModuleMessageRepository()
        {
            _dictionary = new Dictionary<string, List<IMessageSubscription>>();
        }
        
        public void AddSubscriber<T>(string key, IDomainEventHandler<T> domainEventHandler) where T : IDomainEvent
        {
            var subscription = MessageSubscription.Create(domainEventHandler);
            if (_dictionary.ContainsKey(key))
            {
                _dictionary[key].Add(subscription);
            }
            else
            {
                var subscribers = new List<IMessageSubscription> {subscription};
                _dictionary.Add(key, subscribers);
            }
        }

        public IEnumerable<IMessageSubscription> GetSubscribers<T>(string key) where T : IDomainEvent
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