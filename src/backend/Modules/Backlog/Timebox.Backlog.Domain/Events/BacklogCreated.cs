using System;
using Timebox.Modules.Events.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Backlog.Domain.Events
{
    [ModuleOwner(ModuleNames.BacklogsModule)]
    public class BacklogCreated : IDomainEvent
    {
        public BacklogCreated(Guid backlogId)
        {
            BacklogId = backlogId;
        }

        public Guid BacklogId { get; }
    }
}