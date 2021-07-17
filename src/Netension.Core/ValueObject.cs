using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Netension
{
    /// <summary>
    /// Base class of value objects.
    /// </summary>
    /// <remarks>
    /// Value objects are immutable object without identity. Every value object is equal by their properties.
    /// </remarks>
    public abstract class ValueObject
    {
        /// <summary>
        /// Equal operator of ValueObject.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if two value objects are equal, otherwise false.</returns>
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return EqualOperator(left, right);
        }

        /// <summary>
        /// Not equal operator of ValueObject.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if two value objects are not equal, otherwise false.</returns>
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return NotEqualOperator(left, right);
        }

        /// <summary>
        /// Methods of equal operator.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if two value objects are equal, otherwise false.</returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }
            return left is null || left.Equals(right);
        }

        /// <summary>
        /// Methods of not equal operator.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>True if two value objects are not equal, otherwise false.</returns>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !(EqualOperator(left, right));
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        [ExcludeFromCodeCoverage]
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Get values for the equals comparing.
        /// </summary>
        /// <returns>Values of the properties.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();
    }
}
