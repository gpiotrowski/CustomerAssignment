using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAssignment.Common.Core.Domain.Exceptions;
using CustomerAssignment.Common.Core.Events;

namespace CustomerAssignment.Common.Infrastructure.EventStore.InMemoryEventStore
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion = null)
        {
            List<EventDescriptor> eventDescriptors;

            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            else if (CheckIfLatestEventVersionMatchCurrentAggregateVersion(expectedVersion, eventDescriptors))
            {
                throw new ConcurrencyException(aggregateId);
            }

            var i = expectedVersion ?? 0;
            foreach (var @event in events)
            {
                i++;
                @event.Version = i;

                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));
            }
        }

        public List<IEvent> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;

            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException(aggregateId);
            }

            return eventDescriptors.Select(desc => desc.EventData).ToList();
        }

        private static bool CheckIfLatestEventVersionMatchCurrentAggregateVersion(int? expectedVersion, List<EventDescriptor> eventDescriptors)
        {
            return expectedVersion != null && eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion;
        }
    }
}
