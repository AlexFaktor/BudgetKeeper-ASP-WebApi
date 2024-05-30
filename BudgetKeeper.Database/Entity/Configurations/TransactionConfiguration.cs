using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetKeeper.Database.Entity.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<TransactionRecord>
    {
        public void Configure(EntityTypeBuilder<TransactionRecord> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Category)
            .WithMany()
            .HasForeignKey(t => t.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Time)
            .IsRequired()
            .HasColumnType("datetime");
        }
    }
}
