using System;

namespace CustomerAssignment.Common.Core.Domain.Exceptions
{
    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(Guid id)
            : base($"Aggregate {id} was not found")
        { }

        public AggregateNotFoundException(Type t, Guid id)
            : base($"Aggregate {id} of type {t.FullName} was not found")
        { }
    }
}
