using System;
using System.Reflection;

namespace Timebox.Shared.Modules
{
    public class ModuleOwnerKeyService : IModuleOwnerKeyService
    {
        public string GetKeyForMessage<T>()
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<ModuleOwnerAttribute>();
            if (attribute is null)
            {
                throw new InvalidOperationException($@"Please ensure the ModuleOwnerAttribute is applied to class of type {type.FullName}");
            }

            return $"{attribute.Name}/{type.Name}";
        }
    }
}