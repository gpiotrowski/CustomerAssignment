using System;

namespace CustomerAssignment.Common.Core.Domain.Exceptions
{
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(Guid id)
            : base($"Aggregate {id} was not found")
        { }
    }
}
