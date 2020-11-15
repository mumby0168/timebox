using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public class MessageKeyService : IMessageKeyService
    {
        public string GetKeyForMessage<T>() where T : IDomainEvent
        {
            return "test";
        }
    }
}