namespace BudgetKeeper.Models.DTO.TransactionDtos
{
    public class TransactionUpdateDto
    {
        public string Comment { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Time { get; set; }
    }

}
