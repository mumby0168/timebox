using System;
using Timebox.Modules.Events.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Modules.Events
{
    public class ModuleEventSubscriber : IEventSubscriber
    {
        private readonly IModuleEventRegistry _moduleEventRegistry;
        private readonly IModuleOwnerKeyService _moduleOwnerKeyService;
        private readonly IServiceProvider _serviceProvider;

        public ModuleEventSubscriber(IModuleEventRegistry moduleEventRegistry, IModuleOwnerKeyService moduleOwnerKeyService, IServiceProvider serviceProvider)
        {
            _moduleEventRegistry = moduleEventRegistry;
            _moduleOwnerKeyService = moduleOwnerKeyService;
            _serviceProvider = serviceProvider;
        }
        
        public IEventSubscriber Subscribe<T>() where T : IDomainEvent
        {
            var key = _moduleOwnerKeyService.GetKeyForMessage<T>();

            var handlerType = typeof(IDomainEventHandler<>);
            var args = new []{typeof(T)};
            var typeToFind = handlerType.MakeGenericType(args);

            var handler = (IDomainEventHandler<T>)_serviceProvider.GetService(typeToFind);

            if (handler is null)
            {
                throw new InvalidCastException();
            }

            _moduleEventRegistry.AddSubscriber<T>(key, obj=> handler.HandleAsync((T)obj));
            return this;
        }
    }
}