using AutoFixture;
using System.Collections.Generic;
using Xunit;

namespace Netension.Core.UnitTest.Core
{
    public class TestValueObject : ValueObject
    {
        public string Value { get; }

        public TestValueObject(string value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    public class ValueObject_Test
    {
        [Fact(DisplayName = "ValueObject - EqualOperator - Null")]
        public void ValueObject_EqualsOperator_Null()
        {
            // Arrange
            var value = new Fixture().Create<string>();
            var sut = new TestValueObject(value);

            // Act
            // Assert
            Assert.False(sut == null);
        }

        [Fact(DisplayName = "ValueObject - EqualOperator - Equals by properties")]
        public void ValueObject_EqualsOperator_EqualsByProperties()
        {
            // Arrange
            var value = new Fixture().Create<string>();
            var sut = new TestValueObject(value);

            // Act
            // Assert
            Assert.True(sut == new TestValueObject(value));
        }

        [Fact(DisplayName = "ValueObject - EqualOperator - Does not equals by properties")]
        public void ValueObject_EqualsOperator_DoesNotEqualsByProperties()
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            // Assert
            Assert.False(sut == new TestValueObject(new Fixture().Create<string>()));
        }

        [Fact(DisplayName = "ValueObject - NotEqualOperator - Equals by properties")]
        public void ValueObject_NotEqualsOperator_EqualsByProperties()
        {
            // Arrange
            var value = new Fixture().Create<string>();
            var sut = new TestValueObject(value);

            // Act
            // Assert
            Assert.False(sut != new TestValueObject(value));
        }

        [Fact(DisplayName = "ValueObject - NotEqualOperator - Does not equals by properties")]
        public void ValueObject_NotEqualsOperator_DoesNotEqualsByProperties()
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            // Assert
            Assert.True(sut != new TestValueObject(new Fixture().Create<string>()));
        }

        [Fact(DisplayName = "ValueObject - Equals - Equals by properties")]
        public void ValueObject_Equals_EqualsByProperties()
        {
            // Arrange
            var value = new Fixture().Create<string>();
            var sut = new TestValueObject(value);

            // Act
            // Assert
            Assert.True(sut.Equals(new TestValueObject(value)));
        }

        [Fact(DisplayName = "ValueObject - Equals - Do not equals")]
        public void ValueObject_Equals_DoNoEquals()
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            // Assert
            Assert.False(sut.Equals(new TestValueObject(new Fixture().Create<string>())));
        }

        [Fact(DisplayName = "ValueObject - Equals - Null")]
        public void ValueObject_Equals_Null()
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            // Assert
            Assert.False(sut.Equals(null));
        }

        [Fact(DisplayName = "ValueObject - Equals - Different type")]
        public void ValueObject_Equals_DifferentType()
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            // Assert
            Assert.False(sut.Equals(new object()));
        }
    }
}
