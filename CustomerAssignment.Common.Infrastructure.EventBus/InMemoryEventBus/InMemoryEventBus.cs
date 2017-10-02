using System;
using System.Collections.Generic;
using System.Threading;
using CustomerAssignment.Common.Core.EventBus;
using CustomerAssignment.Common.Core.Events;

namespace CustomerAssignment.Common.Infrastructure.EventBus.InMemoryEventBus
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly Dictionary<Type, List<Action<IEvent>>> _eventRoutes = new Dictionary<Type, List<Action<IEvent>>>();

        public void RegisterHandler<T>(Action<T> handler)
        {
            if (!_eventRoutes.TryGetValue(typeof(T), out List<Action<IEvent>> handlers))
            {
                handlers = new List<Action<IEvent>>();
                _eventRoutes.Add(typeof(T), handlers);
            }

            handlers.Add(x => handler((T)x));
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            List<Action<IEvent>> handlers;

            if (!_eventRoutes.TryGetValue(@event.GetType(), out handlers)) return;

            foreach (var handler in handlers)
            {
                var threadHandler = handler;
                ThreadPool.QueueUserWorkItem(x => threadHandler(@event));
            }
        }
    }
}
