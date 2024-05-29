using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Models
{
    public class BudgetTransaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Income { get; set; }
        public string CategoryName { get; set; }

        public BudgetTransaction(TransactionRecord record)
        {
            Id = record.Id;
            Name = record.Name;
            Income = record.Income;
            CategoryName = record.Category.Name;
        }
    }
}
