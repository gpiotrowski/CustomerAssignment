using System;
using CustomerAssignment.Common.Core.Messages;

namespace CustomerAssignment.Common.Core.Events
{
    public interface IEvent : IMessage
    {
        Guid Id { get; set; }
        int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}
