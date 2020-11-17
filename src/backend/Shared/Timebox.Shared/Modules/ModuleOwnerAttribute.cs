using System;

namespace Timebox.Shared.Modules
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