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
        [Fact(DisplayName = "[UNT-VOE001][Success]: Equal by properties")]
        [Trait("Feature", "VOE- Value object equality")]
        public void ValueObjects_EqualByProperties()
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            var result = sut.Equals(new TestValueObject(sut.Value));

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> UnequalTestData = new List<object[]>
        {
            new object[] { default },
            new object[] { new object() },
            new object[] { new TestValueObject(new Fixture().Create<string>()) }
        };
        [Theory(DisplayName = "[UNT-VOE002][Failure]: Unequal value objects")]
        [Trait("Feature", "VOE- Value object equality")]
        [MemberData(nameof(UnequalTestData))]
        public void ValueObjects_UnequalValueObjects(object other)
        {
            // Arrange
            var sut = new TestValueObject(new Fixture().Create<string>());

            // Act
            var result = sut.Equals(other);

            // Assert
            Assert.False(result);
        }
    }
}
