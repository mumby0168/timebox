using System;
using System.Threading.Tasks;
using Moq.AutoMock;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Shouldly;
using Timebox.Modules.Requests;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Shared.Requests.Tests.Models;

namespace Timebox.Shared.Requests.Tests
{
    public class ModuleRequestRegistryTests
    {
        private AutoMocker _mocker;
        private const string TestKey = "key";
        private Func<object, Task<object>> _func = o => Task.FromResult(new object());

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
        }

        [Test]
        public void RegisterRequestHandler_Always_ThrowsWhenKeyAlreadyRegistered()
        {
            //Arrange
            var sut = CreateSut();
            sut.RegisterRequestHandler<SampleRequest>(TestKey, _func);

            //Act
            //Assert
            var exception = Assert
                .Throws<InvalidOperationException>(
                    () => sut.RegisterRequestHandler<SampleRequest>(TestKey, _func));
            exception.Message.ShouldContain(TestKey);
        }
        
        [Test]
        public void RegisterRequestHandler_Always_AddsHandler()
        {
            //Arrange
            var sut = CreateSut();
            

            //Act
            sut.RegisterRequestHandler<SampleRequest>(TestKey, _func);
            //Assert
            var subscription = sut.GetSubscription(TestKey);
            subscription.AsyncAction.ShouldBe(_func);
            subscription.SubscriptionType.ShouldBe(typeof(SampleRequest));
        }

        [Test]
        public void GetSubscription_Always_ThrowsWhenNoHandlerForKey()
        {
            //Arrange
            var sut = CreateSut();
            
            //Act
            //Assert
            var exception = Assert.Throws<InvalidOperationException>(
                () => sut.GetSubscription(TestKey));
            exception.Message.ShouldContain(TestKey);
        }
        
        

        private IRequestRegistry CreateSut() => _mocker.CreateInstance<ModuleRequestRegistry>();
    }
}