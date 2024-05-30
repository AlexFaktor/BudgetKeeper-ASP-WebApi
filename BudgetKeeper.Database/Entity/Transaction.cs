namespace BudgetKeeper.Database.Entity
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public Category Category { get; set; } = new();
        public Guid CategoryId { get; set; } = new();

        public DateTime Time { get; set; } = DateTime.UtcNow;
    } 
}
