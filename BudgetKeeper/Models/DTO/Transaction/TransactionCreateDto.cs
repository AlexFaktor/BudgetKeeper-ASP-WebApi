namespace BudgetKeeper.Models.DTO.Transaction
{
    public class TransactionCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Income { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}
