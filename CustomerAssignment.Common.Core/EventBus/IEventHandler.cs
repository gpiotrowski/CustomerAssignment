using CustomerAssignment.Common.Core.Events;

namespace CustomerAssignment.Common.Core.EventBus
{
    public interface IEventHandler<T> where T : IEvent
    {
        void Handle(T @event);
    }
}