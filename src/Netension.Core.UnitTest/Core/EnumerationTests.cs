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

        [Fact]
        public void Enumeration_Equals_WithSameIds()
        {
            // Arrange
            // Act
            // Assert
            Assert.True(TestEnumeration.FirstTestEnumeration.Equals(TestEnumeration.FirstTestEnumeration));
        }

        [Fact]
        public void Enumeration_Equals_WithDifferencIds()
        {
            // Arrange
            // Act
            // Assert
            Assert.False(TestEnumeration.FirstTestEnumeration.Equals(TestEnumeration.SecondTestEnumeration));
        }
    }
}
