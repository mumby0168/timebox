namespace Timebox.Shared.Modules
{
    public interface IModuleOwnerKeyService
    {
        string GetKeyForMessage<T>();
    }
}