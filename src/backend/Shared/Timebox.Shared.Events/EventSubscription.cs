using System;
using System.Threading.Tasks;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Modules.Events
{
    
    public class EventSubscription : IEventSubscription
    {
        public static IEventSubscription Create<T>(Func<object, Task> action) where T : IDomainEvent
        {
            return new EventSubscription
            {
                AsyncAction = action,
                SubscriptionType = typeof(T)
            };
        }
        public Func<object, Task> AsyncAction { get; private set; }
        public Type SubscriptionType { get; private set; }
    }
}