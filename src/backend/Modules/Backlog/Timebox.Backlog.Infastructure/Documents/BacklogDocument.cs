using System;
using Convey.Types;
using Timebox.Backlog.Domain.Entities;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Backlog.Infastructure.Documents
{
    public class BacklogDocument : IIdentifiable<Guid>
    {
        public BacklogDocument(IBacklogEntity entity)
        {
            Id = entity.Id;
        }
        
        public Guid Id { get; set; }
    }
}