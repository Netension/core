using Netension.Core.EFCore;

namespace Microsoft.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void BuildTable<TEntity>(this ModelBuilder builder, string table)
            where TEntity : Entity
        {
            builder.Entity<TEntity>()
                .ToTable(table)
                .HasKey(e => new { e.Id });

            builder.Entity<TEntity>()
                .Property(e => e.Id)
                .HasColumnName("id");
        }
    }
}
