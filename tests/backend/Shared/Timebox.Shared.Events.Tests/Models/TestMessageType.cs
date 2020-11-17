using System.Threading.Tasks;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Module.Events.Tests.Models
{
    [ModuleOwner("Test")]
    public class TestMessageType : IDomainEvent
    {
        
    }
    
    public class TestMessageTypeNoAttribute : IDomainEvent
    {
        
    }
    
    public class TestMessageTypeHandler : IDomainEventHandler<TestMessageType>
    {
        public bool IsExecuted { get; set; }
        public Task HandleAsync(TestMessageType domainEvent)
        {
            IsExecuted = true;
            return Task.CompletedTask;
        }
    }
}