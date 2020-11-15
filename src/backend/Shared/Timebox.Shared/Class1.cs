using System;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared
{
    public class SampleMessage : IDomainEvent
    {
        public string Message { get; set; }
    }
}
