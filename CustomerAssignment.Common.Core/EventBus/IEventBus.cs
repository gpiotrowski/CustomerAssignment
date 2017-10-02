using System;
using CustomerAssignment.Common.Core.Events;

namespace CustomerAssignment.Common.Core.EventBus
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : IEvent;
        void RegisterHandler<T>(Action<T> handler);
    }
}
