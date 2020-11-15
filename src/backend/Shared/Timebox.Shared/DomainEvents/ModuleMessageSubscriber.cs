using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public class ModuleMessageSubscriber : IMessageSubscriber
    {
        private readonly IModuleMessageRepository _moduleMessageRepository;
        private readonly IMessageKeyService _messageKeyService;
        private readonly IServiceProvider _serviceProvider;

        public ModuleMessageSubscriber(IModuleMessageRepository moduleMessageRepository, IMessageKeyService messageKeyService, IServiceProvider serviceProvider)
        {
            _moduleMessageRepository = moduleMessageRepository;
            _messageKeyService = messageKeyService;
            _serviceProvider = serviceProvider;
        }
        
        public IMessageSubscriber Subscribe<T>() where T : IDomainEvent
        {
            var key = _messageKeyService.GetKeyForMessage<T>();

            var handlerType = typeof(IDomainEventHandler<>);
            var args = new []{typeof(T)};
            var typeToFind = handlerType.MakeGenericType(args);

            var handler = (IDomainEventHandler<T>)_serviceProvider.GetService(typeToFind);

            if (handler is null)
            {
                throw new InvalidCastException();
            }

            _moduleMessageRepository.AddSubscriber<T>(key, obj=> handler.HandleAsync((T)obj));
            return this;
        }
    }
}