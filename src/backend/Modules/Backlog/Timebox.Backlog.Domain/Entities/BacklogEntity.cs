using System;
using System.Runtime.CompilerServices;
using Timebox.Backlog.Domain.Exceptions;

[assembly:InternalsVisibleTo("Timebox.Backlog.Domain.Tests")]

namespace Timebox.Backlog.Domain.Entities
{
    
    public class BacklogEntity : IBacklogEntity
    {
        /// <summary>
        /// Creates a new backlog item
        /// </summary>
        /// <param name="title"></param>
        /// <param name="accountId"></param>
        /// <exception cref="EmptyBacklogTitleException"></exception>
        internal BacklogEntity(string title, Guid accountId)
        {
            Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(title))
                throw new EmptyBacklogTitleException();

            Title = title;
            AccountId = accountId;
        }

        public Guid Id { get; }
        public string Title { get; private set; }
        public Guid AccountId { get; }
        
        
        public void Update(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new EmptyBacklogTitleException();

            Title = title;
        }
        
        
    }
}