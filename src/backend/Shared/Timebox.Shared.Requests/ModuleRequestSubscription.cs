using System;
using System.Threading.Tasks;
using Timebox.Modules.Requests.Interfaces;

namespace Timebox.Modules.Requests
{
    public class ModuleRequestSubscription : IModuleRequestSubscription
    {
        public static IModuleRequestSubscription Create<T>(Func<object, Task<object>> action) where T : IRequest
        {
            return new ModuleRequestSubscription()
            {
                AsyncAction = action,
                SubscriptionType = typeof(T)
            };
        }
        public Func<object, Task<object>> AsyncAction { get; private set; }
        public Type SubscriptionType { get; private set; }
    }
}