using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Models
{
    public class BudgetTransaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string CategoryName { get; set; }

        public BudgetTransaction(TransactionRecord record)
        {
            Id = record.Id;
            Name = record.Name;
            Value = record.Value;
            CategoryName = record.Category.Name;
        }
    }
}
