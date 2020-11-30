using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Timebox.Backlog.Application.Interfaces.Repositories;
using Timebox.Backlog.Domain.Entities;
using Timebox.Backlog.Infastructure.Documents;

namespace Timebox.Backlog.Infastructure.Repository
{
    public class MongoBacklogRepository : IBacklogRepository
    {
        private readonly IMongoRepository<BacklogDocument, Guid> _repository;

        public MongoBacklogRepository(IMongoRepository<BacklogDocument,Guid> repository)
        {
            _repository = repository;
        }
        
        public Task CreateAsync(IBacklogEntity backlog) 
            => _repository.AddAsync(new BacklogDocument(backlog));
    }
}