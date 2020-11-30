using System;
using Timebox.Backlog.Domain.Entities;

namespace Timebox.Backlog.Domain.Aggregates
{
    public interface IBacklogAggregate
    {
        IBacklogEntity Create(string title, Guid accountId);
    }
}