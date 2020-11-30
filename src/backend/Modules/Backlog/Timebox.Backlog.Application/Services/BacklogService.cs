using System.Threading.Tasks;
using Timebox.Backlog.Application.Dtos;
using Timebox.Backlog.Application.Interfaces.Repositories;
using Timebox.Backlog.Application.Interfaces.Services;
using Timebox.Backlog.Domain.Aggregates;
using Timebox.Backlog.Domain.Events;
using Timebox.Modules.Events.Interfaces;

namespace Timebox.Backlog.Application.Services
{
    public class BacklogService : IBacklogService
    {
        private readonly IBacklogRepository _backlogRepository;
        private readonly IBacklogAggregate _backlogAggregate;
        private readonly IUserService _userService;
        private readonly IEventPublisher _eventPublisher;

        public BacklogService(IBacklogRepository backlogRepository, IBacklogAggregate backlogAggregate, 
            IUserService userService, IEventPublisher eventPublisher)
        {
            _backlogRepository = backlogRepository;
            _backlogAggregate = backlogAggregate;
            _userService = userService;
            _eventPublisher = eventPublisher;
        }
        
        
        public async Task CreateAsync(CreateBacklogDto backlogDto)
        {
            var accountId = await  _userService.GetAccountIdForCurrentUserAsync();
            
            var backlog = _backlogAggregate.Create(backlogDto.Title, accountId);

            await _backlogRepository.CreateAsync(backlog);
            await _eventPublisher.PublishDomainEventAsync(new BacklogCreated(backlog.Id));
        }
    }
}