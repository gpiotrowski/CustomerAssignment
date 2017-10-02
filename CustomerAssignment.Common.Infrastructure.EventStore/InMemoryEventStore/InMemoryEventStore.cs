using System;
using System.Collections.Generic;
using System.Linq;
using CustomerAssignment.Common.Core.Domain.Exceptions;
using CustomerAssignment.Common.Core.EventBus;
using CustomerAssignment.Common.Core.Events;

namespace CustomerAssignment.Common.Infrastructure.EventStore.InMemoryEventStore
{
    public class InMemoryEventStore : IEventStore
    {
        private IEventBus EventBus { get; set; }
        private static readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public InMemoryEventStore(IEventBus eventBus)
        {
            EventBus = eventBus;
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion = null)
        {
            expectedVersion = SetExpectedVersionIfNecessary(events, expectedVersion);
            lock (_current)
            {
                List<EventDescriptor> eventDescriptors = GetEventDescriptors(aggregateId, expectedVersion);
                AddPendingEventsToEventDescriptors(aggregateId, events, eventDescriptors);
            }
        }

        public List<IEvent> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;

            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException(aggregateId);
            }

            return eventDescriptors.Select(desc => desc.EventData).OrderBy(desc => desc.Version).ToList();
        }

        private int SetExpectedVersionIfNecessary(IEnumerable<IEvent> events, int? expectedVersion)
        {
            if (expectedVersion == null)
            {
                expectedVersion = events.OrderBy(x => x.Version).First().Version - 1;
            }

            return (int)expectedVersion;
        }

        private void AddPendingEventsToEventDescriptors(Guid aggregateId, IEnumerable<IEvent> events, List<EventDescriptor> eventDescriptors)
        {
            foreach (var @event in events)
            {
                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, @event.Version));
                EventBus.Publish(@event);
            }
        }

        private List<EventDescriptor> GetEventDescriptors(Guid aggregateId, int? expectedVersion)
        {
            if (!_current.TryGetValue(aggregateId, out List<EventDescriptor> eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }
            else if (CheckIfLatestEventVersionMatchCurrentAggregateVersion(expectedVersion, eventDescriptors))
            {
                throw new ConcurrencyException(aggregateId);
            }

            return eventDescriptors;
        }

        private bool CheckIfLatestEventVersionMatchCurrentAggregateVersion(int? expectedVersion, List<EventDescriptor> eventDescriptors)
        {
            return expectedVersion != null && eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion;
        }
    }
}
