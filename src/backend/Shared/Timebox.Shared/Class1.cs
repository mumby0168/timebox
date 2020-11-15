using System;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared
{
    [ModuleOwner("Test")]
    public class SampleMessage : IDomainEvent
    {
        public string Message { get; set; }
    }
}
