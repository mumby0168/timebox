using System;
using System.Threading.Tasks;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IMessageSubscription
    {
        Func<object, Task> AsyncAction { get; }
        
        Type SubscriptionType { get; }
    }
}