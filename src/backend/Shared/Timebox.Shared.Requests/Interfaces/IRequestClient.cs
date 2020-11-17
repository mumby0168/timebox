using System.Threading.Tasks;

namespace Timebox.Modules.Requests.Interfaces
{
    public interface IRequestClient
    {
        Task<TResponse> GetAsync<TResponse, TRequest>(TRequest request);
    }
}