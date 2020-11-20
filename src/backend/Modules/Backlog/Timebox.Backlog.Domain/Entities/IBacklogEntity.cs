using System;

namespace Timebox.Backlog.Domain.Entities
{
    public interface IBacklogEntity
    {
        Guid Id { get; }
        
        string Title { get; }
        
        Guid AccountId { get; }

        void Update(string title);
    }
}