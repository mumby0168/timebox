using Timebox.Shared.Kernel.Exceptions;

namespace Timebox.Backlog.Domain.Exceptions
{
    public class EmptyBacklogTitleException : DomainException
    {
        public override string ErrorCode => "empty_backlog_title";

        public EmptyBacklogTitleException() : base("A backlog requires a title.") {}
    }
}