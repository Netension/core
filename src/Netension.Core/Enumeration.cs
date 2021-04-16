using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Netension.Core
{
    /// <summary>
    /// Base of Enumeration classes.
    /// </summary>
    public abstract class Enumeration : IComparable
    {
        /// <summary>
        /// Unique identifier. Two <see cref="Enumeration"/> instance equal by the Id.
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// Name of the <see cref="Enumeration"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Create a new <see cref="Enumeration"/> instance.
        /// </summary>
        /// <param name="id">Unique identifier of the <see cref="Enumeration"/>.</param>
        /// <param name="name">Name of the <see cref="Enumeration"/>.</param>
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the all value of the <see cref="Enumeration"/>.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="Enumeration"/>.</typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            var fields = typeof(T).GetProperties(BindingFlags.Public |
                                                 BindingFlags.Static |
                                                 BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Enumeration otherValue)) return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        [ExcludeFromCodeCoverage]
        public override string ToString() => Name;

        public int CompareTo(object obj) => Id.CompareTo(((Enumeration)obj).Id);

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
