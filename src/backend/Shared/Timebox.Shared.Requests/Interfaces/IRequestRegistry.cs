using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Timebox.Modules.Requests.Interfaces
{
    public interface IRequestRegistry
    {
        void RegisterRequestHandler<T>(string key, Func<object, Task<object>> function) where T : IRequest;
        IModuleRequestSubscription GetSubscription(string key);
    }
}