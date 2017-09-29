using System;
using System.Collections.Generic;
using CustomerAssignment.Common.Core.Events;
using CustomerAssignment.Common.Core.Infrastructures;

namespace CustomerAssignment.Common.Core.Domain
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();

        public Guid Id { get; protected set; }
        public int Version { get; protected set; }

        protected void ApplyChange(IEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IEvent @event, bool isNew)
        {
            lock (_changes)
            {
                Apply(@event);
                if (isNew)
                {
                    _changes.Add(@event);
                }
                else
                {
                    Id = @event.Id;
                    Version++;
                }
            }
        }

        protected virtual void Apply(IEvent @event)
        {
            this.AsDynamic().Apply(@event);
        }
    }
}
