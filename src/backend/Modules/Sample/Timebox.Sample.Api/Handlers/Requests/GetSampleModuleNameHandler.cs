using System.Threading.Tasks;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Shared.Kernel.Requests.Sample;

namespace Timebox.Sample.Api.Handlers.Requests
{
    public class SampleNameDto
    {
        public string Name { get; set; }
    }
    public class GetSampleModuleNameHandler : IRequestHandler<GetSampleModuleName>
    {
        public Task<object> HandleAsync(GetSampleModuleName request)
        {
            return Task.FromResult((object) new SampleNameDto {Name = "Sample"});
        }
    }
}