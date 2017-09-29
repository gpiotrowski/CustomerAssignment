using System;

namespace CustomerAssignment.Common.Core.Domain.Exceptions
{
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(Guid id)
            : base($"A different version than expected was found in aggregate {id}")
        { }
    }
}
