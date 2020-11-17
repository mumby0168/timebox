using System;
using System.Threading.Tasks;

namespace Timebox.Modules.Events.Interfaces
{
    public interface IEventSubscription
    {
        Func<object, Task> AsyncAction { get; }
        
        Type SubscriptionType { get; }
    }
}