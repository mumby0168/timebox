using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Shouldly;
using Timebox.Shared.DomainEvents;
using Timebox.Shared.DomainEvents.Interfaces;
using Timebox.Shared.Tests.DomainEvents.Models;

namespace Timebox.Shared.Tests.DomainEvents
{
    public class ModuleMessageBrokerTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void PublishDomainEventAsync_Always_CallsSubscribers()
        {
            //Arrange
            var sut = CreateSut();
            var module = "test";
            var subscriptions = new List<IMessageSubscription>();
            var subscription = new Mock<IMessageSubscription>();
            var called = false;
            subscription.SetupGet(o => o.SubscriptionType).Returns(typeof(TestMessageType));
            subscription.SetupGet(o => o.AsyncAction).Returns((o) =>
            {
                called = true;
                return Task.CompletedTask;
            });
            subscriptions.Add(subscription.Object);
            _mocker.GetMock<IMessageKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);
            _mocker.GetMock<IModuleMessageRepository>().Setup(o => o.GetSubscribers<TestMessageType>(module))
                .Returns(subscriptions);

            //Act
            sut.PublishDomainEventAsync(new TestMessageType());

            //Assert
            called.ShouldBeTrue();
        }
        
        [Test]
        public void PublishDomainEventAsync_Always_LogsAndReturnsIfNoSubscribers()
        {
            //Arrange
            var sut = CreateSut();
            var module = "test";
            _mocker.GetMock<IMessageKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);

            //Act
            sut.PublishDomainEventAsync(new TestMessageType());
            //Assert    
        }

        private IMessageBroker CreateSut() => _mocker.CreateInstance<ModuleMessageBroker>();

    }
}