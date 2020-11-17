using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Timebox.Modules.Requests;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Shared.Modules;
using Timebox.Shared.Requests.Tests.Models;

namespace Timebox.Shared.Requests.Tests
{
    public class ModuleRequestSubscriberTests
    {
        private AutoMocker _mocker;
        private const string TestKey = "test";

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void Subscribe_Always_SubscribesHandler()
        {
            //Arrange
            var sut = CreateSut();

            var handler = new SampleRequestHandler();
            
            _mocker.GetMock<IModuleOwnerKeyService>()
                .Setup(o => o.GetKeyForMessage<SampleRequest>())
                .Returns(TestKey);
            
            _mocker.GetMock<IServiceProvider>()
                .Setup(o => o.GetService(typeof(IRequestHandler<SampleRequest>)))
                .Returns(handler);


            //Act
            sut.Subscribe<SampleRequest>();

            //Assert
            _mocker.GetMock<IRequestRegistry>()
                .Verify(o => 
                    o.RegisterRequestHandler<SampleRequest>(TestKey, It.IsAny<Func<object, Task<object>>>()));
        }

        private IRequestSubscriber CreateSut() => _mocker.CreateInstance<ModuleRequestSubscriber>();
    }
}