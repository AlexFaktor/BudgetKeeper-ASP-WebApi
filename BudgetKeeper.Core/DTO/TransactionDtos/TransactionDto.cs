using BudgetKeeper.Database.Entity;

namespace BudgetKeeper.Core.TransactionDtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Time { get; set; } = DateTime.UtcNow;
        public Guid CategoryId { get; set; }

        public TransactionDto()
        {
        }

        public TransactionDto(Transaction record)
        {
            Id = record.Id;
            Comment = record.Comment;
            Amount = record.Amount;
            Time = record.Time;
            CategoryId = record.CategoryId;
        }
    }
}
