using System;

namespace CustomerAssignment.Customers.Domain.Exceptions
{
    public class ClientAlreadyDeletedException : Exception
    {
        public ClientAlreadyDeletedException(Guid id) : base($"Client with id {id} is already deleted")
        {
            
        }
    }
}
