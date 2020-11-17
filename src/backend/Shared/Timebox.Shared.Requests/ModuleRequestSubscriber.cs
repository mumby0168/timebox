using System;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Modules.Requests
{
    public class ModuleRequestSubscriber : IRequestSubscriber
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModuleOwnerKeyService _moduleOwnerKeyService;
        private readonly IRequestRegistry _requestRegistry;

        public ModuleRequestSubscriber(IServiceProvider serviceProvider, IModuleOwnerKeyService moduleOwnerKeyService, IRequestRegistry requestRegistry)
        {
            _serviceProvider = serviceProvider;
            _moduleOwnerKeyService = moduleOwnerKeyService;
            _requestRegistry = requestRegistry;
        }
        
        public IRequestSubscriber Subscribe<TRequest>() where TRequest : IRequest
        {
            var key = _moduleOwnerKeyService.GetKeyForMessage<TRequest>();
            
            var handlerType = typeof(IRequestHandler<>);
            var args = new []{typeof(TRequest)};
            var typeToFind = handlerType.MakeGenericType(args);
            
            var handler = (IRequestHandler<TRequest>) _serviceProvider.GetRequiredService(typeToFind);

            _requestRegistry.RegisterRequestHandler<TRequest>(key,(o) => handler.HandleAsync((TRequest) o));

            return this;
        }
    }
}