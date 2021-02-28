using AutoFixture;
using System.Linq;
using Xunit;

namespace Netension.Core.UnitTest.Core
{
    public class TestEnumeration : Enumeration
    {
        public static TestEnumeration FirstTestEnumeration => new TestEnumeration(1, "TestEnumeration");
        public static TestEnumeration SecondTestEnumeration => new TestEnumeration(2, "TestEnumeration");

        public TestEnumeration(int id, string name) 
            : base(id, name)
        {
        }

    }

    public class EnumerationTests
    {

        [Fact(DisplayName = "Enumeration - Set id")]
        public void Enumeration_SetId()
        {
            // Arrange
            var id = new Fixture().Create<int>();
            var sut = new TestEnumeration(id, null);

            // Act
            // Assert
            Assert.Equal(id, sut.Id);
        }

        [Fact(DisplayName = "Enumeration - Set name")]
        public void Enumeration_SetName()
        {
            // Arrange
            var name = new Fixture().Create<string>();
            var sut = new TestEnumeration(0, name);

            // Act
            // Assert
            Assert.Equal(name, sut.Name);
        }

        [Fact(DisplayName = "Enumeration - Equals - Same ids")]
        public void Enumeration_Equals_WithSameIds()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(TestEnumeration.FirstTestEnumeration.Equals(TestEnumeration.FirstTestEnumeration));
        }

        [Fact(DisplayName = "Enumeration - Equals - Null")]
        public void Enumeration_Equals_Null()
        {
            // Arrange
            // Act
            // Assert
            Assert.False(TestEnumeration.FirstTestEnumeration.Equals(null));
        }

        [Fact(DisplayName = "Enumeration - Equals - DifferentType")]
        public void Enumeration_Equals_DifferentType()
        {
            // Arrange
            // Act
            // Assert
            Assert.False(TestEnumeration.FirstTestEnumeration.Equals(new object()));
        }

        [Fact(DisplayName = "Enumeration - GetAll")]
        public void Enumeration_GetAll()
        {
            // Arrange
            // Act
            var result = Enumeration.GetAll<TestEnumeration>();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(TestEnumeration.FirstTestEnumeration, result);
            Assert.Contains(TestEnumeration.SecondTestEnumeration, result);
        }

        [Fact(DisplayName = "Enumeration - Equals - Different ids")]
        public void Enumeration_Equals_WithDifferencIds()
        {
            // Arrange
            // Act
            // Assert
            Assert.False(TestEnumeration.FirstTestEnumeration.Equals(TestEnumeration.SecondTestEnumeration));
        }
    }
}
