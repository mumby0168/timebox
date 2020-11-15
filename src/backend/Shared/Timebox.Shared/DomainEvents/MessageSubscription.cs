using System;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public class MessageSubscription : IMessageSubscription
    {
        private MessageSubscription(){}
        public object Handler { get; set; }
        public Type ParameterType { get; set; }

        public static IMessageSubscription Create<T>(IDomainEventHandler<T> handler) where T : IDomainEvent
        {
            return new MessageSubscription
            {
                ParameterType = typeof(T),
                Handler = handler
            };
        }
    }
}