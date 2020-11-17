using System;
using System.Linq;
using System.Threading.Tasks;
using Moq.AutoMock;
using NUnit.Framework;
using Shouldly;
using Timebox.Module.Events.Tests.Models;
using Timebox.Modules.Events;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Module.Events.Tests
{
    public class ModuleMessageRepositoryTests
    {
        private AutoMocker _mocker;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void AddSubscriber_Always_AddsSubscribers()
        {
            //Arrange
            var sut = CreateSut();
            string key = "Test/TestMessageType";

            //Act
            sut.AddSubscriber<TestMessageType>(key, new Func<object, Task>((o) => Task.CompletedTask));
            
            //Assert
            sut.GetSubscribers<TestMessageType>(key).Count().ShouldBe(1);
        }
        
        [Test]
        public void AddSubscriber_Always_AddsMoreSubscribers()
        {
            //Arrange
            var sut = CreateSut();
            string key = "Test/TestMessageType";
            sut.AddSubscriber<TestMessageType>(key, new Func<object, Task>((o) => Task.CompletedTask));

            //Act
            sut.AddSubscriber<TestMessageType>(key, new Func<object, Task>((o) => Task.CompletedTask));
            
            //Assert
            sut.GetSubscribers<TestMessageType>(key).Count().ShouldBe(2);
        }

        public void GetSubscribers_Always_ReturnsNullIfNoSubscribers()
        {
            //Arrange
            var sut = CreateSut();
            string key = "Test/TestMessageType";
            
            //Act
            var res = sut.GetSubscribers<TestMessageType>(key);
            
            //Assert
            res.ShouldBeNull();
        }
        
        

        private IModuleEventRegistry CreateSut() => _mocker.CreateInstance<ModuleEventRegistry>();
    }
}