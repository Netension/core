namespace Netension.Core.Domain.Interfaces
{
    public interface IMemento<TState>
        where TState : IEntity
    {
        TState State { get; set; }
    }
}
