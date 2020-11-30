using System;
using Convey.Types;
using Timebox.Backlog.Domain.Entities;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Backlog.Infastructure.Documents
{
    public class BacklogDocument : IIdentifiable<Guid>
    {
        public BacklogDocument()
        {
            
        }
        
        public BacklogDocument(IBacklogEntity entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            AccountId = entity.AccountId;
        }
        
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public Guid AccountId { get; set; }
    }
}