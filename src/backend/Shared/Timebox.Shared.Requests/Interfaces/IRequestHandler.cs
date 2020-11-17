using System.Threading.Tasks;

namespace Timebox.Modules.Requests.Interfaces
{
    public interface IRequestHandler<in TRequest> where TRequest : IRequest
    {
        Task<object> HandleAsync(TRequest request);
    }
}