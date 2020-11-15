using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Timebox.Shared.DomainEvents;
using Timebox.Shared.DomainEvents.Interfaces;
using Timebox.Shared.Tests.DomainEvents.Models;

namespace Timebox.Shared.Tests.DomainEvents
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
            _mocker.GetMock<IMessageKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);

            //Act
            sut.Subscribe<TestMessageType>();

            //Assert
            _mocker.GetMock<IModuleMessageRepository>()
                .Verify(o => o.AddSubscriber<TestMessageType>(module, It.IsAny<Func<object, Task>>()));
        }

        [Test]
        public void Subscribe_Always_ThrowsIfTypeNotRegistered()
        {
            //Arrange
            var sut = CreateSut();
            var module = "test";
            _mocker.GetMock<IMessageKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);

            //Act
            //Assert
            Assert.Throws<InvalidCastException>(() => sut.Subscribe<TestMessageType>());
        }

        private IMessageSubscriber CreateSut() => _mocker.CreateInstance<ModuleMessageSubscriber>();

    }
}