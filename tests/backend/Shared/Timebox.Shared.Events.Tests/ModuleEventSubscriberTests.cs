using System;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Timebox.Module.Events.Tests.Models;
using Timebox.Modules.Events;
using Timebox.Modules.Events.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Module.Events.Tests
{
    public class ModuleMessageSubscriberTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void Subscribe_Always_AddsSubscriber()
        {
            //Arrange
            var sut = CreateSut();
            var module = "test";
            _mocker.GetMock<IServiceProvider>().Setup(o => o.GetService(typeof(IDomainEventHandler<TestMessageType>)))
                .Returns(new TestMessageTypeHandler());
            _mocker.GetMock<IModuleOwnerKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);

            //Act
            sut.Subscribe<TestMessageType>();

            //Assert
            _mocker.GetMock<IModuleEventRegistry>()
                .Verify(o => o.AddSubscriber<TestMessageType>(module, It.IsAny<Func<object, Task>>()));
        }

        [Test]
        public void Subscribe_Always_ThrowsIfTypeNotRegistered()
        {
            //Arrange
            var sut = CreateSut();
            var module = "test";
            _mocker.GetMock<IModuleOwnerKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);

            //Act
            //Assert
            Assert.Throws<InvalidCastException>(() => sut.Subscribe<TestMessageType>());
        }

        private IEventSubscriber CreateSut() => _mocker.CreateInstance<ModuleEventSubscriber>();

    }
}