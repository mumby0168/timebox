namespace Timebox.Modules.Requests.Interfaces
{
    public interface IRequestSubscriber
    {
        IRequestSubscriber Subscribe<TRequest>() where TRequest : IRequest;
    }
}