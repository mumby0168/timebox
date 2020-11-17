using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Timebox.Modules.Events.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Modules.Events
{
    public class ModuleEventPublisher : IEventPublisher
    {
        private readonly IModuleEventRegistry _moduleEventRegistry;
        private readonly IModuleOwnerKeyService _moduleOwnerKeyService;
        private readonly ILogger<ModuleEventPublisher> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ModuleEventPublisher(IModuleEventRegistry moduleEventRegistry, IModuleOwnerKeyService moduleOwnerKeyService, ILogger<ModuleEventPublisher> logger, IServiceProvider serviceProvider)
        {
            _moduleEventRegistry = moduleEventRegistry;
            _moduleOwnerKeyService = moduleOwnerKeyService;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        
        public async Task PublishDomainEventAsync<T>(T @event) where T : IDomainEvent
        {
            var key = _moduleOwnerKeyService.GetKeyForMessage<T>();
            
            var subscriptions = _moduleEventRegistry.GetSubscribers<T>(key);

            if (subscriptions is null)
            {
                _logger.LogWarning($"No subscribers for message with key {key}");
                return;
            }

            var json = JsonConvert.SerializeObject(@event);

            foreach (var subscription in subscriptions)
            {
                await subscription.AsyncAction(JsonConvert.DeserializeObject(json, subscription.SubscriptionType));
            }
        }
    }
}