using System;
using System.Threading;
using System.Threading.Tasks;

namespace Netension.Core.Domain.Interfaces
{
    public interface IRepository<TAggregate, TState>
        where TAggregate : IMemento<TState>
        where TState : class
    {
        Task<TAggregate> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task InsertAsnyc(TAggregate aggregate, CancellationToken cancellationToken);
        Task UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
