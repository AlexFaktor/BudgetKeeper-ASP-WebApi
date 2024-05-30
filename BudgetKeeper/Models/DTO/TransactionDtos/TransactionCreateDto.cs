namespace BudgetKeeper.Models.DTO.TransactionDtos
{
    public class TransactionCreateDto
    {
        public string Comment { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
    }
}
