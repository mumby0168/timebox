namespace Timebox.Modules.Events.Interfaces
{
    public interface IEventSubscriber
    {
        IEventSubscriber Subscribe<T>() where T : IDomainEvent;
    }
}