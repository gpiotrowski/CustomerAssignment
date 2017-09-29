using System;

namespace CustomerAssignment.Common.Core.Domain.Exceptions
{
    public class EventsOutOfOrderException : Exception
    {
        public EventsOutOfOrderException(Guid id)
            : base($"Events received from Event Store for aggregate {id} are out of order")
        { }
    }
}
