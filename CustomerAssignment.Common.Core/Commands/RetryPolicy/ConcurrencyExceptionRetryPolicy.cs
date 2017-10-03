using System;
using CustomerAssignment.Common.Core.Domain.Exceptions;

namespace CustomerAssignment.Common.Core.Commands.RetryPolicy
{
    public static class ConcurrencyExceptionRetryPolicy
    {
        public static void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (ConcurrencyException)
            {
                Execute(action);
            }
        }
    }
}
