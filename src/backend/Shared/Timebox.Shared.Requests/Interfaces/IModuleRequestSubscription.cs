using System;
using System.Threading.Tasks;

namespace Timebox.Modules.Requests.Interfaces
{
    public interface IModuleRequestSubscription
    {
        Func<object, Task<object>> AsyncAction { get; }
        
        Type SubscriptionType { get; }
    }
}