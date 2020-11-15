using System;
using System.Threading.Tasks;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    
    public class MessageSubscription : IMessageSubscription
    {
        public static IMessageSubscription Create<T>(Func<object, Task> action) where T : IDomainEvent
        {
            return new MessageSubscription
            {
                AsyncAction = action,
                SubscriptionType = typeof(T)
            };
        }
        public Func<object, Task> AsyncAction { get; private set; }
        public Type SubscriptionType { get; private set; }
    }
}