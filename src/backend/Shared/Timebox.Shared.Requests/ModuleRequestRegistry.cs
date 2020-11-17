using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timebox.Modules.Requests.Interfaces;

namespace Timebox.Modules.Requests
{
    public class ModuleRequestRegistry : IRequestRegistry
    {
        private IDictionary<string, IModuleRequestSubscription> _dictionary;

        public ModuleRequestRegistry()
        {
            _dictionary = new Dictionary<string, IModuleRequestSubscription>();    
        }
        
        public void RegisterRequestHandler<TRequest>(string key, Func<object, Task<object>> function) where TRequest : IRequest
        {
            if (_dictionary.ContainsKey(key))
            {
                throw new InvalidOperationException($"A subscription has already been made for event with key: {key}");
            }

            _dictionary.Add(key, ModuleRequestSubscription.Create<TRequest>(function));
        }

        public IModuleRequestSubscription GetSubscription(string key)
        {
            if (_dictionary.ContainsKey(key))
                return _dictionary[key];
            
            //TODO: Consider this could be a runtime exception that only occurs when a client makes a request
            throw new InvalidOperationException($"No method to handle ${key} request");
        }
    }
}