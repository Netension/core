using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Core.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Netension.Core.Domain.EFCore
{
    public class Repository<TAggregate, TEntity, TContext> : IRepository<TAggregate, TEntity>
        where TAggregate : AggregateRoot<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly ILogger<Repository<TAggregate, TEntity, TContext>> _logger;

        public Repository(TContext context, ILogger<Repository<TAggregate, TEntity, TContext>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<TAggregate> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return new AggregateRoot<TEntity>(await _context.FindAsync<TEntity>(new object[] { id }, cancellationToken: cancellationToken));
        }

        public Task InsertAsnyc(TAggregate aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TAggregate aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
