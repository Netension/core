using AutoFixture;
using Netension.Core.EFCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace Netension.Core.UnitTest.EFCore
{
    internal class TestEntity : Entity
    {
        public string Value { get; set; }
    }

    public class Entity_Test
    {

        [Fact(DisplayName = "[UNT-EEQ001][Success]: Equal entities")]
        [Trait("Features", "EEQ - Entity equality")]
        public void EqualEntites()
        {
            // Arrange
            var id = Guid.NewGuid();
            var sut = new TestEntity
            {
                Id = id,
                Value = new Fixture().Create<string>()
            };

            // Act
            var result = sut.Equals(new TestEntity { Id = id, Value = new Fixture().Create<string>() });

            // Assert
            Assert.True(result);
        }

        public static IEnumerable<object[]> UnequalTestData = new List<object[]>
        {
            new object[] { default },
            new object[] { new object() },
            new object[] { new TestEntity { Id = Guid.NewGuid(), Value = new Fixture().Create<string>() } }
        };

        [Theory(DisplayName = "[UNT-EEQ002][Failure]: Unequal entities")]
        [Trait("Features", "EEQ - Entity equality")]
        [MemberData(nameof(UnequalTestData))]
        public void UnequalEntities(object otherEntity)
        {
            // Arrange
            var sut = new TestEntity
            {
                Id = Guid.NewGuid(),
                Value = new Fixture().Create<string>()
            };

            // Act
            var result = sut.Equals(otherEntity);

            // Assert
            Assert.False(result);
        }
    }
}
