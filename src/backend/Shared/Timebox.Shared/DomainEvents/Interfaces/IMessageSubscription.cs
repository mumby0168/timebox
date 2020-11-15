using System;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IMessageSubscription
    {
        object Handler { get; set; }
        
        Type ParameterType { get; set; }
    }
}