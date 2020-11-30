using System;
using System.Threading.Tasks;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using Timebox.Backlog.Application.Dtos;
using Timebox.Backlog.Application.Interfaces.Repositories;
using Timebox.Backlog.Application.Interfaces.Services;
using Timebox.Backlog.Application.Services;
using Timebox.Backlog.Domain.Aggregates;
using Timebox.Backlog.Domain.Entities;
using Timebox.Backlog.Domain.Events;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Backlog.Application.Tests.Services
{
    public class BacklogServiceTests
    {
        private AutoMocker _mocker;
        private const string Title = "General";
        private Guid _id = Guid.NewGuid();
        private Guid _accountId = Guid.NewGuid();
        private Mock<IBacklogEntity> _backlog;

        [SetUp]
        public void Setup()
        {
            _mocker = new AutoMocker();
            _backlog = new Mock<IBacklogEntity>();
            _backlog.SetupGet(o => o.Id).Returns(_id);
            _backlog.SetupGet(o => o.Title).Returns(Title);
            _backlog.SetupGet(o => o.AccountId).Returns(_accountId);
        }

        [Test]
        public async Task Create_Always_CreatesBacklog()
        {
            //Arrange
            var sut = CreateSut();
            var dto = new CreateBacklogDto(Title);
            
            _mocker.GetMock<IBacklogAggregate>()
                .Setup(o => o.Create(Title, _accountId))
                .Returns(_backlog.Object);
            
            _mocker.GetMock<IUserService>()
                .Setup(o => o.GetAccountIdForCurrentUserAsync())
                .Returns(Task.FromResult(_accountId));
            
            //Act
            await sut.CreateAsync(dto);

            //Assert
            
            _mocker.GetMock<IBacklogAggregate>()
                .Verify(o => o.Create(Title, _accountId));
            
            _mocker.GetMock<IBacklogRepository>()
                .Verify(o => o.CreateAsync(_backlog.Object));
            
            _mocker.GetMock<IEventPublisher>()
                .Verify(o =>
                    o.PublishDomainEventAsync(
                        It.Is<BacklogCreated>(ev => ev.BacklogId == _backlog.Object.Id)));
        }

        private IBacklogService CreateSut() => _mocker.CreateInstance<BacklogService>();

    }
}