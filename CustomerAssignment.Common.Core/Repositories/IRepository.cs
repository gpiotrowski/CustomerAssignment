using System;
using CustomerAssignment.Common.Core.Domain;

namespace CustomerAssignment.Common.Core.Repositories
{
    public interface IRepository<T> where T : AggregateRoot
    {
        void Save(AggregateRoot aggregate, int? expectedVersion = null);
        T GetById(Guid id);
    }
}