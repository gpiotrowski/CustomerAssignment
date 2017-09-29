namespace CustomerAssignment.Common.Core.Messages
{
    public interface IHandle<T> where T : IMessage
    {
        void Handle(T message);
    }
}
