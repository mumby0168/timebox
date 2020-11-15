namespace Timebox.Shared.DomainEvents.Interfaces
{
    public interface IMessageKeyService
    {
        string GetKeyForMessage<T>() where T : IDomainEvent;
    }
}