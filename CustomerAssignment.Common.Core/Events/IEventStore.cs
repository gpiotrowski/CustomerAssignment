using System;
using System.Collections.Generic;

namespace CustomerAssignment.Common.Core.Events
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int? expectedVersion = null);
        List<IEvent> GetEventsForAggregate(Guid aggregateId);
    }
}
