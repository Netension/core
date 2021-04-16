using System;
using System.Collections.Generic;

namespace Netension.Core
{
    public interface IEntity : IEqualityComparer<IEntity>
    {
        Guid Id { get; }
    }
}
