namespace Netension.Core.Domain.Interfaces
{
    public interface IMemento<TState>
    {
        TState State { get; set; }
    }
}
