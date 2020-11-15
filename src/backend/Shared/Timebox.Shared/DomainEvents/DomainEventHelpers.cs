namespace Timebox.Shared.DomainEvents
{
    public static class DomainEventHelpers
    {
        public static T Marshall<T>(object domainEvent) => (T) domainEvent;
    }
}