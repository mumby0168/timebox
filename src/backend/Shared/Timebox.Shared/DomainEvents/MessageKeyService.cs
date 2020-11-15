using System;
using System.Reflection;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public class MessageKeyService : IMessageKeyService
    {
        public string GetKeyForMessage<T>() where T : IDomainEvent
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<ModuleOwnerAttribute>();
            if (attribute is null)
            {
                throw new InvalidOperationException($@"Please ensure the ModuleOwnerAttribute is applied to domain entity of type {type.FullName}");
            }

            return $"{attribute.Name}/{type.Name}";
        }
    }
}