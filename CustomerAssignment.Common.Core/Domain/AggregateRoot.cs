using System;

namespace CustomerAssignment.Common.Core.Domain
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; protected set; }
        public int Version { get; protected set; }
    }
}
