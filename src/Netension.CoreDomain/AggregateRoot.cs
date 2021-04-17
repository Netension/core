using Netension.Core.Domain.Interfaces;

namespace Netension.Core.Domain
{
    public class AggregateRoot<TState> : IMemento<TState>
    {
        TState IMemento<TState>.State { get; set; }

        public AggregateRoot(TState state)
        {
            ((IMemento<TState>)this).State = state;
        }
    }
}
