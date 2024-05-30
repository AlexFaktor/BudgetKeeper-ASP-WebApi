using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Models
{
    public class BudgetTransaction
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string CategoryName { get; set; }

        public BudgetTransaction(Transaction record)
        {
            Id = record.Id;
            Name = record.Comment;
            Value = record.Amount;
            CategoryName = record.Category.Name;
        }
    }
}
