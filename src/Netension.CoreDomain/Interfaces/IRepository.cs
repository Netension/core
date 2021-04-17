using System;
using System.Threading;
using System.Threading.Tasks;

namespace Netension.Core.Domain.Interfaces
{
    public interface IRepository<TState>
        where TState : class
    {
        Task<AggregateRoot<TState>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task InsertAsnyc(IMemento<TState> aggregate, CancellationToken cancellationToken);
        Task UpdateAsync(IMemento<TState> aggregate, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
