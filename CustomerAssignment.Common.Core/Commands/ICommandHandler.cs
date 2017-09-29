using CustomerAssignment.Common.Core.Messages;

namespace CustomerAssignment.Common.Core.Commands
{
    public interface ICommandHandler<T> : IHandle<T> where T : ICommand
    {
    }
}
