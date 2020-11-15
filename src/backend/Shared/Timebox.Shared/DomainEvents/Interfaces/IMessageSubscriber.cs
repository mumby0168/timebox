namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IMessageSubscriber
    {
        IMessageSubscriber Subscribe<T>() where T : IDomainEvent;
    }
}