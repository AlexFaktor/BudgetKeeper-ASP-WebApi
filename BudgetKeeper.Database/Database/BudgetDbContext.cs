using BudgetKeeper.Database.Entity;
using BudgetKeeper.Database.Entity.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BudgetKeeper.Database.Database
{
    public class BudgetDbContext : DbContext 
    {
        public DbSet<CategoryRecord> Categories { get; set; }
        public DbSet<TransactionRecord> Transactions { get; set; }

        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
