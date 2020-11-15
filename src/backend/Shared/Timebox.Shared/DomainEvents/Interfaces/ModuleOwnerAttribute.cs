using System;

namespace Timebox.Shared.DomainEvents.Interfaces
{
    public class ModuleOwnerAttribute : Attribute
    {
        public ModuleOwnerAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}