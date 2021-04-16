using AutoFixture;
using System.Collections.Generic;
using Xunit;

namespace Netension.Core.UnitTest.Core
{
    public class TestEnumeration : Enumeration
    {
        public static TestEnumeration First => new TestEnumeration(0, default);
        public static TestEnumeration Second => new TestEnumeration(1, default);

        public TestEnumeration(int id, string name)
            : base(id, name)
        {
        }

    }

    public class EnumerationTests
    {

        [Fact(DisplayName = "[UNT-ESP001][Success]: Set Id")]
        [Trait("Feature", "ESP - Enumeration set base properties")]
        public void Enumeration_SetId()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var sut = new TestEnumeration(id, null);

            // Act
            // Assert
            Assert.Equal(id, sut.Id);
        }

        [Fact(DisplayName = "[UNT-ESP001][Success]: Set Name")]
        [Trait("Feature", "ESP - Enumeration set base properties")]
        public void Enumeration_SetName()
        {
            // Arrange
            var name = new Fixture().Create<string>();
            var sut = new TestEnumeration(0, name);

            // Act
            // Assert
            Assert.Equal(name, sut.Name);
        }

        [Fact(DisplayName = "[UNT-EEQ001][Success]: Equal Enumeration instances")]
        [Trait("Feature", "EEQ - Enumeration equality")]
        public void Enumeration_Equals_WithSameIds()
        {
            // Arrange
            var id = 1;
            var enumeration = new TestEnumeration(id, null);

            // Act
            var result = enumeration.Equals(new TestEnumeration(id, null));

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> UnequalTestData = new List<object[]>
        {
            new object[] { default },
            new object[] { new object() },
            new object[] { new TestEnumeration(2, null) }
        };
        [Theory(DisplayName = "[UNT-EEQ001][Failure]: Unequal Enumeration instances")]
        [Trait("Feature", "EEQ - Enumeration equality")]
        [MemberData(nameof(UnequalTestData))]
        public void Enumeration_Unequals(object other)
        {
            // Arrange
            var enumeration = new TestEnumeration(1, default);

            // Act
            var result = enumeration.Equals(other);

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "[UNT-EGA001]: GetAll Enumeration value")]
        [Trait("Feature", "EGA - Get all value of Enumeration")]
        public void Enumeration_GetAll()
        {
            // Arrange
            // Act
            var result = Enumeration.GetAll<TestEnumeration>();

            // Assert
            Assert.Collection(result, value => value.Equals(TestEnumeration.First), value => value.Equals(TestEnumeration.Second));
        }
    }
}
