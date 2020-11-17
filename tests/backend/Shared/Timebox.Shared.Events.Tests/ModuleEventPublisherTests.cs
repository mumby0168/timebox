using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Shouldly;
using Timebox.Module.Events.Tests.Models;
using Timebox.Modules.Events;
using Timebox.Modules.Events.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Module.Events.Tests
{
    public class ModuleEventPublisherTests
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
            var subscriptions = new List<IEventSubscription>();
            var subscription = new Mock<IEventSubscription>();
            var called = false;
            subscription.SetupGet(o => o.SubscriptionType).Returns(typeof(TestMessageType));
            subscription.SetupGet(o => o.AsyncAction).Returns((o) =>
            {
                called = true;
                return Task.CompletedTask;
            });
            subscriptions.Add(subscription.Object);
            _mocker.GetMock<IModuleOwnerKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);
            _mocker.GetMock<IModuleEventRegistry>().Setup(o => o.GetSubscribers<TestMessageType>(module))
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
            _mocker.GetMock<IModuleOwnerKeyService>().Setup(o => o.GetKeyForMessage<TestMessageType>()).Returns(module);

            //Act
            sut.PublishDomainEventAsync(new TestMessageType());
            //Assert    
        }
        
        private IEventPublisher CreateSut() => _mocker.CreateInstance<ModuleEventPublisher>();

    }
}