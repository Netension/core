using System;

namespace Netension.Core.EFCore
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public bool Equals(IEntity other)
        {
            return Id.Equals(other.Id);
        }

        public bool Equals(IEntity x, IEntity y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(IEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
