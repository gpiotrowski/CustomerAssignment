using CustomerAssignment.Common.Core.Commands;

namespace CustomerAssignment.Common.Core.Buses
{
    public interface ICommandSender<T> where T : ICommand
    {
        void Send(T command);
    }
}
