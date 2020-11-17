using System.Threading.Tasks;
using Timebox.Modules.Requests.Interfaces;

namespace Timebox.Shared.Requests.Tests.Models
{
    public class SampleRequest : IRequest
    {
        
    }

    public class SampleRequestResponse
    {
        public SampleRequestResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
    
    public class SampleRequestResponseAgain
    {
        public SampleRequestResponseAgain(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
    
    public class SampleRequestHandler : IRequestHandler<SampleRequest>
    {
        public Task<object> HandleAsync(SampleRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}