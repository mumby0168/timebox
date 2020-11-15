using System;
using Moq.AutoMock;
using NUnit.Framework;
using Shouldly;
using Timebox.Shared.DomainEvents;
using Timebox.Shared.DomainEvents.Interfaces;
using Timebox.Shared.Tests.DomainEvents.Models;

namespace Timebox.Shared.Tests.DomainEvents
{
    public class MessageKeyServiceTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void GetKeyForMessage_Always_ReturnsModuleForType()
        {
            //Arrange
            var sut = CreateSut();

            //Act
            var str = sut.GetKeyForMessage<TestMessageType>();

            //Assert
            str.ShouldBe("Test/TestMessageType");
        }

        [Test]
        public void GetKeyForMessage_Always_ThrowsIfAttributeDoesNotExist()
        {
            //Arrange
            var sut = CreateSut();
            
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.GetKeyForMessage<TestMessageTypeNoAttribute>());
        }
        
        

        private IMessageKeyService CreateSut() => _mocker.CreateInstance<MessageKeyService>();
    }
}