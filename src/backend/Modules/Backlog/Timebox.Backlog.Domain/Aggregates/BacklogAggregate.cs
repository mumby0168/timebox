using System;
using Timebox.Backlog.Domain.Entities;

namespace Timebox.Backlog.Domain.Aggregates
{
    public class BacklogAggregate : IBacklogAggregate
    {
        public IBacklogEntity Create(string title, Guid accountId)
        {
            return new BacklogEntity(title, accountId);
        }
    }
}