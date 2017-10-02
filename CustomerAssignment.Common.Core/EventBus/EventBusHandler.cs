namespace CustomerAssignment.Common.Core.EventBus
{
    public abstract class EventBusHandler
    {
        protected IEventBus _eventBus { get; set; }

        protected EventBusHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
            RegisterHandlers();
        }

        protected abstract void RegisterHandlers();
    }
}
