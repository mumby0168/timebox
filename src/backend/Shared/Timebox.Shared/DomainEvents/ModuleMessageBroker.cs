using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public class ModuleMessageBroker : IMessageBroker
    {
        private readonly IModuleMessageRepository _moduleMessageRepository;
        private readonly IMessageKeyService _messageKeyService;
        private readonly ILogger<ModuleMessageBroker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ModuleMessageBroker(IModuleMessageRepository moduleMessageRepository, IMessageKeyService messageKeyService, ILogger<ModuleMessageBroker> logger, IServiceProvider serviceProvider)
        {
            _moduleMessageRepository = moduleMessageRepository;
            _messageKeyService = messageKeyService;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        
        public async Task PublishDomainEventAsync<T>(T @event) where T : IDomainEvent
        {
            var key = _messageKeyService.GetKeyForMessage<T>();
            
            var subscriptions = _moduleMessageRepository.GetSubscribers<T>(key);

            if (subscriptions is null)
            {
                _logger.LogWarning($"No subscribers for message with key {key}");
                return;
            }

            var json = JsonSerializer.Serialize(@event);

            foreach (var subscription in subscriptions)
            {
                await subscription.AsyncAction(JsonSerializer.Deserialize(json, subscription.SubscriptionType));
            }
        }
    }
}