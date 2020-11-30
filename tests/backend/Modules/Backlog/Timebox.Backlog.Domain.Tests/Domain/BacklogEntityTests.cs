using System;
using NUnit.Framework;
using Shouldly;
using Timebox.Backlog.Domain.Entities;
using Timebox.Backlog.Domain.Exceptions;

namespace Timebox.Backlog.Domain.Tests.Domain
{
    public class BacklogEntityTests
    {
        private Guid _accountId = Guid.NewGuid();
        private const string Title = "My First Backlog";
        
        [Test]
        public void Ctor_Always_CreatesBacklog()
        {
            //Arrange
            //Act
            var backlog = new BacklogEntity(Title, _accountId);

            //Assert
            backlog.Id.ShouldNotBe(Guid.Empty);
            backlog.Title.ShouldBe(Title);
            backlog.AccountId.ShouldBe(_accountId);
        }

        [Test]
        public void Ctor_Always_ThrowsIfTitleEmpty()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<EmptyBacklogTitleException>(() => new BacklogEntity("", _accountId));
        }
    }
}