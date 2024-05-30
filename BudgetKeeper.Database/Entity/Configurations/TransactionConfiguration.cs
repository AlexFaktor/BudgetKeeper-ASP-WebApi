using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetKeeper.Database.Entity.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Comment)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.Category)
            .WithMany()
            .HasForeignKey(t => t.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.Time)
            .IsRequired()
            .HasColumnType("datetime");
        }
    }
}
