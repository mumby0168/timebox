using System;

namespace Timebox.Modules.Events.Interfaces
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