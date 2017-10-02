using System;
using System.Linq;
using CustomerAssignment.Common.Core.Domain;
using CustomerAssignment.Common.Core.Domain.Exceptions;
using CustomerAssignment.Common.Core.Domain.Factories;
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
            return LoadAggregate(id);
        }

        private T LoadAggregate(Guid aggregateId)
        {
            var events = _storage.GetEventsForAggregate(aggregateId);
            if (!events.Any())
            {
                throw new AggregateNotFoundException(typeof(T), aggregateId);
            }

            var aggregate = AggregateFactory.CreateAggregate<T>();
            aggregate.LoadFromHistory(events);
            return aggregate;
        }
    }
}
