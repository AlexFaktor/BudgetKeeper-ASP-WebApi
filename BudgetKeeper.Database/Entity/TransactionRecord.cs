namespace BudgetKeeper.Database.Entity
{
    public class TransactionRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }

        public CategoryRecord Category { get; set; } = new();
        public Guid CategoryId { get; set; } = new();

        public DateTime Time { get; set; } = DateTime.UtcNow;
    } 
}
