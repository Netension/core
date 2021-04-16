using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Netension.Core.Domain;
using Netension.Core.Domain.EFCore;
using Netension.Core.Domain.Interfaces;
using Netension.Core.EFCore;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Netension.Core.UnitTest.EFCore
{
    internal class TestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("RepositoryTest");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Repository_Test
    {
        private readonly ILogger<Repository<AggregateRoot<Entity>, Entity, TestContext>> _logger;

        public Repository_Test(ITestOutputHelper outputHelper)
        {
            _logger = new LoggerFactory()
                        .AddXUnit(outputHelper)
                        .CreateLogger<Repository<AggregateRoot<Entity>, Entity, TestContext>>();
        }

        private Repository<AggregateRoot<Entity>, Entity, TestContext> CreateSUT()
{
            return new Repository<AggregateRoot<Entity>, Entity, TestContext>(new TestContext(), _logger);
        }

        [Fact(DisplayName = "[UNT-EFG001][Success]: Get entity by Id")]
        [Trait("Feature", "EFG - Get by Id")]
        public async Task EFCoreRepository_GetEntityById()
        {
            // Arrange
            var sut = CreateSUT();
            var entity = new Fixture().Create<Entity>();

            // Act
            var result = await sut.GetByIdAsync(entity.Id, default);

            // Assert
            Assert.Equal(entity, ((IMemento<Entity>)result).State);
        }
    }
}
