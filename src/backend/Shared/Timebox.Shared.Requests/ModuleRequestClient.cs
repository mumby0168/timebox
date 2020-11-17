using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Modules.Requests
{
    public class ModuleRequestClient : IRequestClient
    {
        private readonly ILogger<ModuleRequestClient> _logger;
        private readonly IRequestRegistry _requestRegistry;
        private readonly IModuleOwnerKeyService _moduleOwnerKeyService;

        public ModuleRequestClient(ILogger<ModuleRequestClient> logger, IRequestRegistry requestRegistry, IModuleOwnerKeyService moduleOwnerKeyService)
        {
            _logger = logger;
            _requestRegistry = requestRegistry;
            _moduleOwnerKeyService = moduleOwnerKeyService;
        }
        
        public async Task<TResponse> GetAsync<TResponse, TRequest>(TRequest request)
        {
            var key = _moduleOwnerKeyService.GetKeyForMessage<TRequest>();

            var json = JsonConvert.SerializeObject(request);

            var subscription = _requestRegistry.GetSubscription(key);
            
            var result = 
                await subscription.AsyncAction(JsonConvert.DeserializeObject(json, subscription.SubscriptionType));

            var responseJson = JsonConvert.SerializeObject(result);

            return JsonConvert.DeserializeObject<TResponse>(responseJson);
        }
    }
}