using System;
using CustomerAssignment.Common.Core.Domain;
using CustomerAssignment.Common.Core.Events;

namespace CustomerAssignment.Common.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly IEventStore _storage;

        public Repository(IEventStore storage)
        {
            _storage = storage;
        }

        public void Save(AggregateRoot aggregate, int? expectedVersion = null)
        {
            _storage.SaveEvents(aggregate.Id, aggregate.FlushUncommitedChanges(), expectedVersion);
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
