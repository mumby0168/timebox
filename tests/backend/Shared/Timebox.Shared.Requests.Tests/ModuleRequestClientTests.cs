using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Shouldly;
using Timebox.Modules.Requests;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Shared.Modules;
using Timebox.Shared.Requests.Tests.Models;

namespace Timebox.Shared.Requests.Tests
{
    public class ModuleRequestClientTests
    {
        private AutoMocker _mocker;
        private const string TestKey = "test";
        private const string TestValue = "value";

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }


        [Test]
        public async Task GetAsync_Always_ReturnsCorrectData()
        {
            //Arrange
            var sut = CreateSut();
            _mocker.GetMock<IModuleOwnerKeyService>()
                .Setup(o => o.GetKeyForMessage<SampleRequest>()).Returns(TestKey);
            
            var subscription = new Mock<IModuleRequestSubscription>();
            subscription.SetupGet(o => o.SubscriptionType)
                .Returns(typeof(SampleRequest));
            
            subscription.SetupGet(o => o.AsyncAction)
                .Returns((o => 
                    Task.FromResult((object)new SampleRequestResponse(TestValue))
                    ));

            _mocker.GetMock<IRequestRegistry>()
                .Setup(o => o.GetSubscription(TestKey))
                .Returns(subscription.Object);

            //Act
            var result = await sut.GetAsync<SampleRequestResponseAgain, SampleRequest>(new SampleRequest());

            //Assert
            result.Message.ShouldBe(TestValue);
        }
        
        

        private IRequestClient CreateSut() => _mocker.CreateInstance<ModuleRequestClient>();
    }
}